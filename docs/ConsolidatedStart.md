# TacoTracker

An app for tracking taco-related guesses and scoring them once results are validated.

## Tech stack

- .NET (ASP.NET Core MVC)
- PostgreSQL (via Docker locally)
- Entity Framework Core — schema/migrations only
- Dapper — application queries

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- EF Core CLI tools:
  ```bash
  dotnet tool install --global dotnet-ef
  ```
  (if already installed, update with `dotnet tool update --global dotnet-ef`)

## Local setup

1. **Clone the repo**
   ```bash
   git clone <repo-url>
   cd TacoTracker
   ```

2. **Start Postgres**
   ```bash
   docker compose up -d
   ```
   This spins up a Postgres 16 container (`tacotracker-db`) on port `5432`, matching the connection string in `appsettings.json`. Data persists across restarts via a Docker volume.

3. **Apply database migrations**
   ```bash
   dotnet ef database update
   ```
   This creates the schema (tables, etc.) based on the current model classes and migration history in `Migrations/`.

4. **Run the app**
   ```bash
   dotnet run
   ```

## Everyday workflow

- **Start your day:** `docker compose up -d` (if not already running)
- **Stop the DB:** `docker compose down` (data is preserved — the volume isn't removed)
- **Wipe the DB completely and start fresh:** `docker compose down -v` (this deletes the volume, all data lost)

## Making schema changes

EF Core auto-generates migrations by diffing your model classes (in `Models/`) against the last known schema snapshot. You never hand-write migration SQL.

1. Edit the relevant class in `Models/` (e.g. `Guess.cs`) — add, remove, or change properties
2. Generate a migration:
   ```bash
   dotnet ef migrations add DescriptiveNameForTheChange
   ```
3. Apply it to your local database:
   ```bash
   dotnet ef database update
   ```

Commit the generated migration files (in `Migrations/`) along with your model changes — teammates will run `dotnet ef database update` after pulling to apply them locally.

> **Note:** EF Core is used here *only* for schema/migrations. All actual application queries (reads/writes at runtime) go through Dapper directly — see `Models/TrackerManager.cs`.

## Connecting to the database directly

To inspect the database via `psql` without installing it locally:

```bash
docker exec -it tacotracker-db psql -U tacouser -d tacotracker
```

Useful commands once connected:
- `\dt` — list tables
- `SELECT * FROM "Guesses";` — view guess data (note: double quotes needed, Postgres is case-sensitive with EF's capitalized table names)
- `\q` — exit

## Troubleshooting

- **`psql: command not found`** — you don't need it installed locally; use the `docker exec` command above instead.
- **App can't connect to the database** — check `docker ps` to confirm `tacotracker-db` is running (status should say `Up`, not `Restarting` or missing).
- **Migrations out of sync / unexpected schema errors** — confirm you've run `dotnet ef database update` after the latest `git pull`.
