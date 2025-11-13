
# Project Overview

Beagl is a modern CRM for animal centers. It centralizes management of animals, owners, and employees, provides a self-service portal, facilitates adoption and annual fee payments, and offers reporting tools and a secure web interface.

## Technologies Used

- .NET 10
- ASP.NET Core
- Blazor and Razor Pages
- Entity Framework Core
- Docker (deployment)
- PostgreSQL (development and production)
- Identity with EF Core for user and role management

## Main Features & Workflows

- Domain entity and role management
- Data access and migrations
- Authentication and authorization
- Employee management (profiles, details)
- Animal registration and tracking
- Adoption workflow
- Owner portal (self-service, annual fee payment)
- Payment processing
- Data centralization
- Reporting tools

## Design Patterns & Architecture

- Layered architecture: Domain, Infrastructure, Application, WebApp
- SOLID principles and Clean Architecture
- Patterns used: Repository, Dependency Injection, Factory, Singleton, Strategy, Adapter, Observer, Mediator, Command, CQRS, Specification

## Naming and Formatting Conventions

- PascalCase for classes, methods, properties
- camelCase for local variables and parameters
- Prefix 'I' for interfaces (e.g., `IAnimalRepository`)
- Explicit and descriptive names
- Tab indentation (per `.editorconfig`)
- Line length: max 120 characters
- Braces on new line

## Error Handling and Logging

- Use exceptions for errors
- Only catch exceptions if handled
- Use custom exception types if relevant
- Logging via ASP.NET Core `ILogger<T>`
- Do not log sensitive information
- Use structured logging for complex data

## Data Sources

- PostgreSQL database for all environments

## Configuration and Deployment

- Dockerfile for web app deployment
- EF Core migrations in `src/Beagl.Saas.Infrastructure/Migrations/`
- Configuration files in `src/Beagl.Saas.WebApp/`

## Commit Message Guidelines

- Use Conventional Commits, lowercase (e.g., `feat: add login form partial`)
- Include a clear summary of the change
- For breaking changes, add `BREAKING CHANGE:` in the message body and describe the impact

**Important: The commit type prefix must be in English (feat, fix, chore, etc.), but the summary and description should be written in French.**

Example: `feat: ajout du formulaire d’adoption`

## Code Standards and Style

- Source code must be written in English (variable, function, class names, etc.)
- Comments and documentation must be in French, clear and precise
- Follow clean code principles: simplicity, readability, modularity, avoid duplication
- Follow Microsoft style recommendations for the language used
- Indentation must be tabs, per `.editorconfig`
- Use `.editorconfig` as the main linter for code quality and consistency
- C# analyzers are used and all warnings are treated as errors during compilation
- Document all public functions and main classes
- Avoid code duplication: prefer reuse via functions or classes
- Favor simplicity and readability: code understandable by all team members
- Modularize code: separate responsibilities into distinct modules or classes
- Respect Single Responsibility Principle
- Use explicit names for variables, functions, and classes
- Add unit tests for critical functions
- Limit file and function size for maintainability
- Document entry points and public APIs
- Respect commit conventions (e.g., Conventional Commits) if applicable
- Commit messages must follow Conventional Commits for clarity and traceability

## Folder and Project Structure

The repository contains the following projects:

- `src/Beagl.Saas.WebApp`: main web app (hybrid Blazor and Razor Pages)
    - Should contain: controllers, viewmodels, pages, UI components, integration services, UI-specific config
- `src/Beagl.Saas.Infrastructure`: infrastructure layer (data access, external services)
    - Should contain: repositories, data contexts, persistence DTOs, external integrations, technical config
- `src/Beagl.Saas.Application`: application logic (use cases, business services)
    - Should contain: application services, exchange DTOs, use case management, domain/infrastructure mapping
- `src/Beagl.Saas.Domain`: domain model and business rules
    - Should contain: entities, aggregates, value objects, repository interfaces, business rules, domain exceptions

Tests are organized similarly:

- `tests/Beagl.Saas.WebApp.Tests`: web app tests (controllers, UI, integration)
- `tests/Beagl.Saas.Infrastructure.Tests`: infrastructure tests (repositories, data access)
- `tests/Beagl.Saas.Application.Tests`: application logic tests (services, use cases)
- `tests/Beagl.Saas.Domain.Tests`: domain tests (entities, aggregates, business rules)

Each project must include:
All projects must include:
- A `README.md` file with specific instructions
- Source code in the `src/` folder as described
- Unit tests in the `tests/` folder as described
- Required config files (`.editorconfig`, etc.)

## Contribution Instructions

To contribute to the project:

- Fork the repository or create a branch from `main`
- Follow code standards and folder structure
- Clearly document changes made
- Add unit tests for any new feature or fix
- Submit a pull request (PR) with a Conventional Commits-compliant message
- Briefly describe the purpose and impact of the PR
- Wait for review and approval before merging

## Tests

All projects must include unit tests and, if relevant, integration tests.

- Unit tests must cover critical functions and business rules
- Integration tests must validate correct module interaction
- Test folders are organized as: `tests/Beagl.Saas.[ProjectName].Tests`
- Tests must be easily executable via standard language tools
- Any new feature or fix must be accompanied by relevant tests

## Common Commands

Here are some useful commands for development and running the project:

- **Build project**: `dotnet build`
- **Run tests**: `dotnet test`
- **Launch web app**: `dotnet run --project src/Beagl.Saas.WebApp`
- **Check code style**: per `.editorconfig` (automatic in most IDEs)

See the `README.md` files in each project for additional specific instructions.

## Documentation and Copilot Guidelines

- All technical and functional documentation must be written in French, in the `docs/` folder or in each project's `README.md`
- Highlight important points or architectural choices in comments
- For Copilot: avoid generating code in folders not listed in the structure, follow the conventions and standards above
- Prefer recommended libraries and tools for the project

**Important: All code generation must strictly follow the rules defined in the `.editorconfig` file at the project root.**
This includes:
- Indentation (spaces or tabs per config)
- UTF-8 encoding
- LF line endings
- No trailing whitespace
- Naming and documentation conventions
- C# style preferences (explicit types, private fields prefixed, `readonly`, initializers, etc.)
- Explicit access modifiers
- Remove unused `using` statements
- XML documentation for public members
- Other analyzer rules and recommendations in `.editorconfig`
