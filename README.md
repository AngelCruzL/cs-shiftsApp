# Shifts App

## Setup

After clone the repository, run the following command to up the database service (only if you don't want to use your own
database):

```bash
docker-compose up -d
```

Then, run the following command to make the migrations:

```bash
dotnet ef database update
```

```bash
dotnet watch --no-hot-reload
```