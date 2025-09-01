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

---

## Database Setup (PostgreSQL with Docker)

You need Docker installed on your development machine. Download it from [https://www.docker.com/products/docker-desktop](https://www.docker.com/products/docker-desktop).

### 1. Create a `.env` file

At the root of the repository, create a file named `.env` with the following content:

```env
POSTGRES_PASSWORD=your-strong-password
```

Replace `your-strong-password` with a secure password of your choice.

### 2. Start the PostgreSQL database

Run the following command from the repository root:

```sh
docker-compose up -d
```

This will start a PostgreSQL database container with the configuration from `docker-compose.yml`.

### 3. Stop the database

To stop the database, run:

```sh
docker-compose down
```

---

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

## Seeding the Default Admin User with User Secrets

To avoid storing sensitive data in source code, you should use [dotnet user-secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets) for development. This allows you to provide the default admin user's credentials securely for seeding.

### Setting User Secrets


From the `src/Beagl.WebApp` folder, run:

```sh
dotnet user-secrets init
dotnet user-secrets set "SeedData:SeedUser:Email" "admin@localhost"
dotnet user-secrets set "SeedData:SeedUser:Password" "your-strong-password"
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=beagl;Username=beagl_admin;Password=your-strong-password"
```

Replace `your-strong-password` with a secure password of your choice.

Your application will read these values from configuration when seeding the database.

> Note: The `your-strong-password` value in your connection string must match the `POSTGRES_PASSWORD` value in your `.env` file.

---


## Entity Framework Core (EF Core) & PostgreSQL

This project uses [Entity Framework Core 8](https://learn.microsoft.com/en-us/ef/core/) with PostgreSQL as the development and production database provider.

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
