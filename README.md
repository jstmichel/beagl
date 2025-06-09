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

## Contributing

We welcome contributions! Please see [CONTRIBUTING.md](CONTRIBUTING.md) for guidelines.

## License

[MIT](LICENSE)
