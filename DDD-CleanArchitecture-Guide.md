
# DDD & Clean Architecture in C# with EF Core

This guide is designed to help you understand and implement Domain-Driven Design (DDD) and Clean Architecture in C# using Entity Framework Core. It covers the essential building blocks, their purpose, where to place them in your solution, and practical code examples. Each section includes context, best practices, and actionable tips to help you apply these concepts in real-world projects.


## 1. Solution Structure

Organize your solution into clear, logical layers to enforce separation of concerns and maintainability:

- **Domain Layer** (`Beagl.Domain`): Contains the core business logic, including Entities, Value Objects, Aggregates, Domain Events, Domain Services, and business interfaces. This layer should have no dependencies on other layers.
- **Application Layer** (`Beagl.Application`): Coordinates use cases, orchestrates workflows, and exposes application services. Contains DTOs, use case logic, and application-level specifications. Depends only on the Domain layer.
- **Infrastructure Layer** (`Beagl.Infrastructure`): Implements data access (e.g., EF Core DbContext, repositories), external integrations, and data mappers. Depends on both Domain and Application layers.
- **Web Layer** (`Beagl.WebApp`): User interface, including Controllers, Razor Pages, API Endpoints, and ViewModels. Depends on Application and Infrastructure layers.

**Tip:** Keep dependencies flowing inward (Web → Application → Domain). The Domain layer should never depend on Application, Infrastructure, or Web.

---

## 2. Key DDD Building Blocks


### Entity

**What:** An object with a unique identity (Id) that persists throughout its lifecycle. Entities are mutable and represent concepts with a distinct identity (e.g., Animal, User).

**Where:** Place in `Beagl.Domain/YourContext/Entities/`.

**How:**

```csharp
public abstract class Entity
{
    public Guid Id { get; protected set; }
    // Equality overrides...
}
```


### Value Object

**What:** An immutable object with no identity, defined only by its properties. Used for concepts that are described by their value (e.g., Address, Money).

**Where:** Place in `Beagl.Domain/YourContext/ValueObjects/`.

**How:**

```csharp
public record Address(string Street, string City, string ZipCode);
```


### Aggregate Root

**What:** An Entity that acts as the main entry point for a group of related entities and value objects. Aggregates enforce business invariants and transactional consistency.

**Where:** Place in `Beagl.Domain/YourContext/Entities/` or a dedicated `Aggregates/` folder.

**How:**

```csharp
public class Order : AggregateRoot
{
    public List<OrderItem> Items { get; private set; }
    // Business logic here
}
```


### Domain Event

**What:** An object that represents something significant that happened in the domain (e.g., AnimalRegistered, OrderPlaced). Used to decouple side effects and enable event-driven workflows.

**Where:** Place in `Beagl.Domain/YourContext/Events/`.

**How:**

```csharp
public interface IDomainEvent { }

public class AnimalRegisteredEvent : IDomainEvent
{
    public Guid AnimalId { get; }
    public AnimalRegisteredEvent(Guid animalId) => AnimalId = animalId;
}
```


#### Raising and Dispatching Domain Events

**Why:** Raising domain events allows you to react to important business changes (e.g., send notifications, update other systems) without tightly coupling your domain logic to infrastructure or side effects.

- Raise events in aggregate methods:
    ```csharp
    public class Animal : AggregateRoot
    {
        public void Register()
        {
            // ... business logic ...
            AddDomainEvent(new AnimalRegisteredEvent(this.Id));
        }
    }
    ```
- Collect events in the aggregate root:
    ```csharp
    public abstract class AggregateRoot : Entity
    {
        private readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
        protected void AddDomainEvent(IDomainEvent eventItem) => _domainEvents.Add(eventItem);
        public void ClearDomainEvents() => _domainEvents.Clear();
    }
    ```
- Dispatch after saving (e.g., in `DbContext.SaveChangesAsync()`):
    ```csharp
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var result = await base.SaveChangesAsync(cancellationToken);
        var entitiesWithEvents = ChangeTracker.Entries<AggregateRoot>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .ToList();

        foreach (var entity in entitiesWithEvents)
        {
            foreach (var domainEvent in entity.DomainEvents)
            {
                await _mediator.Publish(domainEvent, cancellationToken);
            }
            entity.ClearDomainEvents();
        }
        return result;
    }
    ```
- Handle with MediatR:
    ```csharp
    public class AnimalRegisteredEventHandler : INotificationHandler<AnimalRegisteredEvent>
    {
        public Task Handle(AnimalRegisteredEvent notification, CancellationToken cancellationToken)
        {
            // React to the event (e.g., send email, update read model, etc.)
            return Task.CompletedTask;
        }
    }
    ```

---


### Repository

**What:** An interface that abstracts data access for aggregates/entities. Repositories provide methods to add, retrieve, and remove aggregates, hiding the details of data storage.

**Where:**
    - Interface: `Beagl.Domain/YourContext/Repositories/`
    - Implementation: `Beagl.Infrastructure/YourContext/Repositories/`

**How:**

```csharp
public interface IAnimalRepository
{
    Task<Animal> GetByIdAsync(Guid id);
    Task AddAsync(Animal animal);
    // ...
}
```


### Application Service vs Domain Service

**Application Service**

- **What:** Coordinates use cases, orchestrates workflows, and exposes application logic to the outside world (e.g., controllers, UI). Should not contain business rules, only workflow logic.
- **Where:** `Beagl.Application/YourContext/Services/`
- **How:**

#### Application Service
- Orchestrates use cases, calls repositories, maps to DTOs, handles transactions, security, etc.
- Contains no business logic, only workflow.

```csharp
public class AnimalAppService : IAnimalAppService
{
    private readonly IAnimalRepository _repo;
    public async Task<IEnumerable<AnimalDto>> GetAllAsync() =>
        (await _repo.GetAllAsync()).Select(AnimalMapper.ToDto);
}
```


**Domain Service**

- **What:** Encapsulates domain logic that doesn't naturally fit within a single entity or value object (e.g., operations involving multiple aggregates).
- **Where:** `Beagl.Domain/YourContext/Services/`
- **How:**

```csharp
public interface IAnimalDomainService
{
    bool CanBeAdopted(Animal animal);
}

public class AnimalDomainService : IAnimalDomainService
{
    public bool CanBeAdopted(Animal animal)
    {
        // Domain rules here
        return !animal.IsDangerousDog;
    }
}
```

---


### Specification Pattern

**What:** A pattern for encapsulating business rules, validation, or query logic into reusable, composable objects. Specifications can be used for both in-memory validation and database queries.

**Why:**
- Avoids scattering rules across services, controllers, or repositories.
- Promotes reusability, testability, and clarity.
- Enables combining rules (e.g., AND, OR, NOT) for complex scenarios.

**Where:**
- **Domain Layer:** For business rules (e.g., "Is animal adoptable?").
- **Application Layer:** For use-case-specific rules or queries.
- **Infrastructure Layer:** For EF Core/LINQ query expressions.

**How:**


#### Where to Place Specifications

| Layer           | Purpose                        | Example File Location                                      |
|-----------------|-------------------------------|------------------------------------------------------------|
| Domain          | Business rules                 | `Beagl.Domain/AnimalManagement/Specifications/`            |
| Application     | Use-case-specific rules/queries| `Beagl.Application/AnimalManagement/Specifications/`       |
| Infrastructure  | EF/LINQ query expressions      | `Beagl.Infrastructure/AnimalManagement/Specifications/`    |


#### Example: Domain Specification (Business Rule)

Use domain specifications to encapsulate business rules that can be reused in entities, domain services, or validation logic.

**File:** `src/Beagl.Domain/AnimalManagement/Specifications/CanBeAdoptedSpecification.cs`

```csharp
public interface ISpecification<T>
{
    bool IsSatisfiedBy(T entity);
}

public class CanBeAdoptedSpecification : ISpecification<Animal>
{
    public bool IsSatisfiedBy(Animal animal)
    {
        return !animal.IsDangerousDog && animal.Status == AnimalStatus.Available;
    }
}
```

**Usage in Domain Service:**

```csharp
var spec = new CanBeAdoptedSpecification();
if (spec.IsSatisfiedBy(animal))
{
    // Proceed with adoption
}
```


#### Example: Query Specification (EF Core)

Use query specifications to encapsulate filtering logic for repositories, making queries reusable and testable.

**File:** `src/Beagl.Infrastructure/AnimalManagement/Specifications/DangerousDogSpecification.cs`

```csharp
using System;
using System.Linq.Expressions;

public interface IQuerySpecification<T>
{
    Expression<Func<T, bool>> ToExpression();
}

public class DangerousDogSpecification : IQuerySpecification<Animal>
{
    public Expression<Func<Animal, bool>> ToExpression()
        => animal => animal.IsDangerousDog;
}
```

**Usage in Repository:**

```csharp
public async Task<IEnumerable<Animal>> FindAsync(IQuerySpecification<Animal> spec)
{
    return await _db.Animals.Where(spec.ToExpression()).ToListAsync();
}
```


#### Composing Specifications

Specifications can be combined using logical operators (AND, OR, NOT) to build complex rules from simple ones. This makes your business logic more modular and maintainable.

```csharp
public class AndSpecification<T> : ISpecification<T>
{
    private readonly ISpecification<T> _left, _right;
    public AndSpecification(ISpecification<T> left, ISpecification<T> right)
    {
        _left = left; _right = right;
    }
    public bool IsSatisfiedBy(T entity) => _left.IsSatisfiedBy(entity) && _right.IsSatisfiedBy(entity);
}
```


#### When to Use Specifications

- When a rule or filter is used in multiple places (domain logic, queries, validation).
- When you want to compose rules (e.g., combine multiple specifications for complex scenarios).
- When you want to keep business rules out of services and controllers, making them reusable and testable.

- When a rule or filter is used in multiple places (domain logic, queries, validation).
- When you want to compose rules (e.g., combine multiple specifications).
- When you want to keep business rules out of services and controllers.


#### Key Takeaways

- **Domain Specifications:** Encapsulate business rules, used in domain logic/services. Place in the Domain layer.
- **Query Specifications:** Encapsulate query logic, used in repositories with EF Core. Place in the Infrastructure layer.
- **Composability:** Specifications can be combined for complex rules.
- **Testability:** Specifications are easy to unit test and reuse.

- **Domain Specifications:** Encapsulate business rules, used in domain logic/services.
- **Query Specifications:** Encapsulate query logic, used in repositories with EF Core.
- **Composability:** Specifications can be combined for complex rules.
- **Testability:** Specifications are easy to unit test.

---


### Factory

**What:** A class or method responsible for creating complex aggregates or entities, especially when construction involves multiple steps or invariants.

**Where:** Place in `Beagl.Domain/YourContext/Factories/` or alongside the aggregate.

**How:**

```csharp
public static class AnimalFactory
{
    public static Animal Create(string name, string species)
    {
        // ... validation, setup ...
        return new Animal(name, species);
    }
}
```

---


### Mapping Entity to DTO

**What:** Mapping domain entities to Data Transfer Objects (DTOs) is essential for exposing data to the outside world (e.g., API, UI) without leaking domain internals.

**Where:** Place mappers in `Beagl.Application/YourContext/Mappers/` or `Beagl.Infrastructure/YourContext/Mappers/`.

**How:**

```csharp
public static class AnimalMapper
{
    public static AnimalDto ToDto(Animal animal) => new()
    {
        Id = animal.Id,
        Name = animal.Name,
        // ...
    };
}
```

---


## 3. Controller/Endpoint Example

Controllers (or Razor Pages) are the entry point for HTTP requests. They should be thin, delegating all business logic to application services. This keeps your web layer simple and focused on request/response handling.

```csharp
[ApiController]
[Route("api/[controller]")]
public class AnimalsController : ControllerBase
{
    private readonly IAnimalAppService _service;
    [HttpGet]
    public async Task<IActionResult> Get() =>
        Ok(await _service.GetAllAsync());
}
```

---


## 4. EF Core Repository Implementation

Repository implementations use EF Core to persist and retrieve aggregates. Keep repositories focused on aggregate boundaries and avoid leaking infrastructure details into the domain.

```csharp
public class AnimalRepository : IAnimalRepository
{
    private readonly ApplicationDbContext _db;
    public async Task<Animal> GetByIdAsync(Guid id) =>
        await _db.Animals.FindAsync(id);
    public async Task AddAsync(Animal animal) =>
        await _db.Animals.AddAsync(animal);
    // Save handled by Unit of Work or Service
}
```

---


## 5. Communication & Update Flow Diagram

This diagram shows the typical flow of a request and how updates and events propagate through the layers:

```plaintext
[Controller/Razor Page]
        |
        v
[Application Service]
        |
        v
[Domain Service] (optional)
        |
        v
[Aggregate Root] <--- [Repository]
        |   ^             |
        |   |             v
        |   |      [DbContext/EF Core]
        |   |             |
        |   |             v
        |   |     [Database]
        v
[Domain Event(s) raised]
        |
        v
[DbContext.SaveChangesAsync()]
        |
        v
[Domain Events Dispatched (Mediator)]
        |
        v
[Domain Event Handlers]
        |
        v
[Side Effects: Email, Integration, Read Model, etc.]
```

---


## 6. DDD Patterns Cheat Sheet

This table summarizes the main DDD patterns, their purpose, and where to implement them in your solution.

| Pattern         | Purpose                                 | Example/Tip                                 |
|-----------------|-----------------------------------------|---------------------------------------------|
| Entity          | Identity, mutable                       | `public Guid Id { get; }`                   |
| Value Object    | No identity, immutable                  | `record Address(...)`                       |
| Aggregate Root  | Consistency boundary                    | `Order` with `OrderItems`                   |
| Repository      | Data access abstraction                 | `IAnimalRepository`                         |
| Domain Event    | Notify about domain changes             | `AnimalRegisteredEvent`                     |
| Application Svc | Orchestrate use cases, map DTOs         | `AnimalAppService`                          |
| Domain Svc      | Domain logic not in entity/VO           | `AnimalDomainService`                       |
| Factory         | Complex creation logic                  | `AnimalFactory.Create(...)`                 |
| Specification   | Encapsulate business rules/queries      | `ISpecification<T>`                         |

---


## 7. Best Practices

Follow these best practices to ensure your codebase remains maintainable, testable, and aligned with DDD and Clean Architecture principles:

- Use interfaces for repositories/services
- Keep domain pure (no EF or infrastructure code)
- Use DTOs for data transfer (never expose entities directly)
- Use dependency injection for services/repositories
- Raise domain events in aggregates, handle in application/infrastructure
- Use value objects for concepts with rules (e.g., Email, Money)
- Keep controllers thin; delegate to services

---


## 8. References & Further Reading

Explore these resources for deeper understanding and real-world examples:

- [Microsoft DDD Guide](https://docs.microsoft.com/en-us/azure/architecture/microservices/model/domain-driven-design)
- [Vaughn Vernon: DDD Distilled](https://www.amazon.com/Domain-Driven-Design-Distilled-Vaughn-Vernon/dp/0134434420)
- [Jimmy Bogard: Contoso University DDD Sample](https://github.com/jbogard/ContosoUniversityDotNetCore)

---

Let me know if you want a more detailed code sample, a diagram in another format, or a specific scenario explained!
