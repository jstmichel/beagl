# Copilot Context for Beagl

## Application Goal
Beagl is designed for animal centers as a centralized CRM. It enables employees to manage animal and owner data, and provides a self-service portal for animal owners to register their animals and pay annual fees. The main objective is to unify and centralize data that is currently spread across multiple systems.

## Project Overview
Beagl is a .NET solution using ASP.NET Core and Blazor for web development. It is organized into domain, infrastructure, and web application layers, with corresponding test projects.

## Technologies
- .NET 8 (C#, default language version)
- ASP.NET Core
- Razor pages
- Entity Framework Core
- Docker (for deployment)
- Identity with EF Core for User and Roles

## Solution Structure
- `beagl.sln`: Solution file
- `src/Beagl.Domain/`: Domain models and business logic
- `src/Beagl.Infrastructure/`: Data access, EF Core migrations, database initialization
- `src/Beagl.WebApp/`: Blazor web application, configuration, resources, components
- `tests/`: Unit and integration tests for each layer

## Main Features & Workflows
- Domain entities and role management
- Infrastructure for database access and migrations
- User authentication and authorization
- Employee management (profiles, details)
- Animal registration and tracking
- Animal adoption workflow
- Owner portal for self-service (animal registration, fee payment)
- Fee payment processing (annual fees)
- Centralized data management for animals and owners
- Reporting tools for operations and finance

## Coding Guidelines
- All public methods must include XML documentation comments describing their purpose, parameters, and return values.
- **Naming Conventions:** Use PascalCase for class, method, and property names. Use camelCase for local variables and parameters. Prefix interfaces with 'I' (e.g., `IAnimalRepository`). Use meaningful, descriptive names for all identifiers.
- **Code Formatting:** Follow the default .NET/C# formatting conventions. Use 4 spaces for indentation. Place opening braces on a new line. Remove unused code and imports. Keep lines under 120 characters where possible.
- **Error Handling:** Use exceptions for error conditions. Catch exceptions only when you can handle them meaningfully. Avoid swallowing exceptions. Use custom exception types where appropriate.
- **Logging Practices:** Use the built-in ASP.NET Core logging framework (`ILogger<T>`). Log errors, warnings, and important events. Avoid logging sensitive information. Use structured logging for complex data.
- **Other Standards:** Write unit and integration tests for all business logic. Avoid magic numbers and strings; use constants or enums. Document public APIs and endpoints. Ensure code is self-explanatory and maintainable.
- Static methods are permitted in classes if they do not reference instance members and this usage does not produce warnings or errors.

## Build & Run
- Build: `dotnet build beagl.sln`
- Run: `dotnet watch run --project src/Beagl.WebApp/Beagl.WebApp.csproj`
- Publish: `dotnet publish src/Beagl.WebApp/Beagl.WebApp.csproj`

## Testing
- Test projects in `tests/` folder
- Run tests: `dotnet test` (from solution root)

## Coding Conventions
- Clean Code principles (Robert C. Martin)
- Clean Architecture (layered separation, dependency inversion)
- C# best practices
- Layered architecture: Domain, Infrastructure, WebApp
- Tests mirror structure of main projects
- Use internal sealed classes per default
- Use global namespaces in files
- Use explicit types

## Design Patterns & Practices
- Use design patterns recommended by Clean Code and Clean Architecture (Robert C. Martin)
- Common patterns and their application in Beagl:
    - **Repository:** Used for data access in the Domain and Infrastructure layers, e.g., managing animal and owner records via interfaces like `IAnimalRepository`.
    - **Dependency Injection:** Enables loose coupling and testability, e.g., injecting services such as payment processors or authentication handlers into controllers and Blazor components.
    - **Factory:** Used for creating domain entities or service instances, e.g., generating new animal or fee objects based on registration input.
    - **Singleton:** Applied to shared resources such as configuration providers or logging services, ensuring a single instance throughout the application.
    - **Strategy:** Used for interchangeable business logic, e.g., different fee calculation strategies for various animal types or adoption workflows.
    - **Adapter:** Facilitates integration with external systems, e.g., adapting third-party payment gateways or legacy data sources to Beagl's interfaces.
    - **Observer:** Used for event-driven features, e.g., notifying employees or owners of status changes in animal registration or adoption.
    - **Mediator:** Coordinates complex workflows, e.g., managing communication between different modules during the animal adoption process.
    - **Command:** Encapsulates actions such as fee payments or animal registrations, supporting undo/redo and audit logging.
    - **CQRS (Command Query Responsibility Segregation):** Separates read and write operations for scalability and maintainability, e.g., querying animal data versus processing registration commands.
- Favor SOLID principles and separation of concerns
- Emphasize testability and maintainability

## Notes
- Dockerfile present for web app deployment
- EF Core migrations in `src/Beagl.Infrastructure/Migrations/`
- Configuration files in `src/Beagl.WebApp/`

## User Roles
- Administrator
- Animal Control
- Employee
- Security (Police)
- Development (Developers)
- Finance
- Board Member

## Data Sources
- Currently uses SQLite for development and testing
- Planned migration to PostgreSQL for production

## Commit Message Guidelines
Use conventional commit messages, all in lower case (e.g., `feat: add login form partial`).
Always include a brief summary of the change in the commit message.
If a change is breaking, add `BREAKING CHANGE:` in the commit message body and describe the impact.
