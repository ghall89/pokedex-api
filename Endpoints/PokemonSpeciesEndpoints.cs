using Server.Data;
using Microsoft.EntityFrameworkCore;

namespace Server.Endpoints;

public static class PokemonSpeciesEndpoints
{
    // hardcoded language id
    // will replace when Language model is built out
    private const int EnglishLanguageId = 9;

    public static void MapPokemonSpeciesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/species");

        group.MapGet("/", async (
            PokedexDbContext db,
            HttpContext httpContext,
            int page = 1,
            int pageSize = 20
        ) => {
            var totalCount = await db.PokemonSpecies.CountAsync();
            var species = await db.PokemonSpecies
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            foreach (var s in species)
            {
                s.Url = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/species/{s.Id}";
            }

            return Results.Ok(new
                {
                    page,
                    pageSize,
                    totalCount,
                    totalPages = (int)Math.Ceiling(totalCount / (double)pageSize),
                    items = species,
                }
            );
        });

        group.MapGet("/{id}", async (int id, PokedexDbContext db) => {
            var species = await db.PokemonSpecies
                .Include(s => s.EvolvesFromSpecies)
                .Include(s => s.Color)
                .Include(s => s.Shape)
                .Include(s => s.Habitat)
                .Include(s => s.FlavorTexts.Where(ft => ft.LanguageId == EnglishLanguageId))
                .FirstOrDefaultAsync(s => s.Id == id);
            if (species is null) return Results.NotFound();
            return Results.Ok(species);
        });
    }
}
