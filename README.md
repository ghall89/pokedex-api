# Pokedex Server

A basic HTTP server built in C# / ASP.NET Core, backed by a SQLite database. This is a learning project for getting hands-on with C# and ASP.NET Core fundamentals: minimal APIs, EF Core.

## Stack

- **.NET 10** / ASP.NET Core Minimal APIs (no MVC controllers)
- **EF Core** with the SQLite provider, querying `PokedexDbContext` directly from endpoints (no repository layer)
- **pokedex.sqlite** — a pre-populated Pokémon data set ([teamdandelion/PokemonSQLTutorial](https://github.com/teamdandelion/PokemonSQLTutorial))

## Project structure

```
Program.cs                          Entry point: DI registration, endpoint wiring
Data/PokedexDbContext.cs            EF Core DbContext
Endpoints/                          Route groups, one file per resource
Models/                             Entity classes mapped to SQLite tables
appsettings.json                    Config, including the SQLite connection string
```

## Running it

```
dotnet run
```

## Endpoints

| Method | Route           | Description                   |
| ------ | --------------- | ----------------------------- |
| GET    | `/`             | Health check placeholder      |
| GET    | `/health`       | Health check                  |
| GET    | `/species`      | List all Pokémon species      |
| GET    | `/species/{id}` | Get one Pokémon species by id |

## Data model

Currently mapped from `pokedex.sqlite`:

- `pokemon_species` → `PokemonSpecies`
- `pokemon` → `Pokemon`
- `pokemon_colors` → `PokemonColor`
- `pokemon_habitats` → `PokemonHabitat`
- `pokemon_shapes` → `PokemonShape`
- `pokemon_species_flavor_text` → `PokemonSpeciesFlavorText`
