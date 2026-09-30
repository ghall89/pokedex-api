# Pokedex Server

A basic HTTP server built in C# / ASP.NET Core, backed by a SQLite database. This is a learning project for getting hands-on with C# and ASP.NET Core fundamentals: minimal APIs, EF Core.

## Stack

- **.NET 10** / ASP.NET Core Minimal APIs (no MVC controllers)
- **EF Core** with the SQLite provider, querying `PokedexDbContext` directly from endpoints (no repository layer)
- **pokedex.sqlite** — a pre-populated Pokémon data set ([teamdandelion/PokemonSQLTutorial](https://github.com/teamdandelion/PokemonSQLTutorial))

## Project structure

```
src/Pokedex.API/                          API layer
  Program.cs                              Entry point: DI registration, endpoint wiring
  Endpoints/                               Route groups, one file per resource
  appsettings.json                        Config, including the SQLite connection string
src/Pokedex.Domain/                       Data/domain layer
  Data/PokedexDbContext.cs                EF Core DbContext
  Models/                                 Entity classes mapped to SQLite tables
  Interfaces/                             Shared entity contracts (e.g. IHasUrl)
  Extensions/                             Query/shaping helpers (e.g. IEnumerable extensions)
```

## Running it

```
dotnet run --project src/Pokedex.API/Pokedex.API.csproj
```

## Endpoints

| Method | Route           | Description                                                                                          |
| ------ | --------------- | ---------------------------------------------------------------------------------------------------- |
| GET    | `/`             | Health check placeholder                                                                             |
| GET    | `/health`       | Health check                                                                                         |
| GET    | `/species`      | List Pokémon species, paginated (`page`, `pageSize` query params, default 1/20)                      |
| GET    | `/species/{id}` | Get one Pokémon species by id, with evolution, color, shape, habitat, stats, and English flavor text |

## Data model

Currently mapped from `pokedex.sqlite`:

- `pokemon_species` → `PokemonSpecies`
- `pokemon` → `Pokemon`
- `pokemon_colors` → `PokemonColor`
- `pokemon_habitats` → `PokemonHabitat`
- `pokemon_shapes` → `PokemonShape`
- `pokemon_species_flavor_text` → `PokemonSpeciesFlavorText`
