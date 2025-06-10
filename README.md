# Beagl

Beagl is an open source application to help animal service organizations manage everything they need: employees, clients, animals, and more.

## Features

- Employee management
- Client tracking
- Animal database
- ...and more!

## Getting Started

1. Clone the repo: `git clone https://github.com/jstmichel/beagl.git`
2. Install dependencies
3. Run the app

## Client-side Library Management (LibMan)

This project uses [LibMan (Library Manager)](https://learn.microsoft.com/en-us/aspnet/core/client-side/libman/) to manage client-side libraries.

### Installing the LibMan CLI

If you don't have the LibMan CLI installed, you can install it globally using the following command:

```sh
dotnet tool install -g Microsoft.Web.LibraryManager.Cli
```

### Common Commands

- **Restore libraries:**
  ```sh
  libman restore
  ```
- **Add a library:**
  ```sh
  libman install <library-name> --provider cdnjs
  ```
- **Clean libraries:**
  ```sh
  libman clean
  ```

Library configuration is stored in `libman.json` at the project root (or in the relevant web project folder).

For more details, see the [LibMan documentation](https://learn.microsoft.com/en-us/aspnet/core/client-side/libman/libman-cli).

---

## Entity Framework Core (EF Core) & SQLite

This project uses [Entity Framework Core 8](https://learn.microsoft.com/en-us/ef/core/) with SQLite as the development database provider.

### Installing EF Core Tools

To use EF Core migrations and database commands, install the .NET EF CLI tool globally:

```sh
dotnet tool install --global dotnet-ef
```

### Common EF Core Commands

- **Add a migration** (from the WebApp project folder):
  ```sh
  dotnet ef migrations add <MigrationName> --project ../Beagl.Infrastructure --startup-project .
  ```
- **Update the database** (apply migrations):
  ```sh
  dotnet ef database update --project ../Beagl.Infrastructure --startup-project .
  ```
- **Rollback the last migration**:
  ```sh
  dotnet ef database update <PreviousMigrationName> --project ../Beagl.Infrastructure --startup-project .
  ```
- **Remove the last migration** (if not applied to the database):
  ```sh
  dotnet ef migrations remove --project ../Beagl.Infrastructure --startup-project .
  ```

> Replace `<MigrationName>` with your desired migration name, and `<PreviousMigrationName>` with the name of the migration you want to roll back to.

For more details, see the [EF Core CLI documentation](https://learn.microsoft.com/en-us/ef/core/cli/dotnet).

## Contributing

We welcome contributions! Please see [CONTRIBUTING.md](CONTRIBUTING.md) for guidelines.

## License

[MIT](LICENSE)
