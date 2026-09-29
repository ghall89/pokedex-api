using Server.Data;
using Microsoft.EntityFrameworkCore;

namespace Server.Endpoints;

public static class PokemonSpeciesEndpoints
{
    public static void MapPokemonSpeciesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/species");

        group.MapGet("/", async (PokedexDbContext db) =>
        {
            var species = await db.PokemonSpecies.ToListAsync();
            return Results.Ok(species);
        });

        group.MapGet("/{id}", async (int id, PokedexDbContext db) => {
           var species = await db.PokemonSpecies.FindAsync(id);
           if (species is null) return Results.NotFound();
           return Results.Ok(species);
        });
    }
}
