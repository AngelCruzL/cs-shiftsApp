# Shifts App

This web application allows us to manage the information of one medical center, where we can track the medical
professionals shifts.

## Features

- CRUD operations for the medical specialities
- CRUD operations for the medical professionals
- CRUD operations for the patients

## Technologies

- .NET 7
- ASP.NET Core 7
- Entity Framework Core 7
- SQL Server
- Docker
- Docker Compose

## What I Learned

- How to create a web application using ASP.NET Core
- How to use the MVC pattern to create a web application
- How to use Entity Framework Core to manage the database
- How to use Docker and Docker Compose to manage the database service with an SQL Server image

## Requirements

- [.NET 7](https://dotnet.microsoft.com/download/dotnet/7.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Or you can use the Docker image
  attached)
- [Docker](https://docs.docker.com/get-docker/) (only if you don't want to use your own database)
- [Docker Compose](https://docs.docker.com/compose/install/) (only if you don't want to use your own database)

## Setup

After clone the repository, you need to have running an SQL Server service. You can use your own database or you can run
the following command to up the database service (only if you don't want to use your own database):

```bash
docker-compose up -d
```

Then, run the following command to make the migrations:

```bash
dotnet ef database update
```

If the ef command is not found, you need to install the Entity Framework Core CLI tool:

```bash
dotnet tool install --global dotnet-ef
```

Finally, run the following command to start the application:

```bash
dotnet watch run
```

This will be running the application in the port 5266. You can access to the application in the following URL:
http://localhost:5266/

## Author

- [Ángel Cruz](https://angelcruzl.dev)

## License

This project is open source and available under the [MIT License](https://choosealicense.com/licenses/mit/).