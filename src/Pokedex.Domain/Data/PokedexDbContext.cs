using Microsoft.EntityFrameworkCore;
using Pokedex.Domain.Models;

namespace Pokedex.Domain.Data;

public class PokedexDbContext : DbContext
{
    public PokedexDbContext(DbContextOptions<PokedexDbContext> options)
        : base(options)
    {
    }

    public DbSet<PokemonSpecies> PokemonSpecies { get; set; } = null!;
}
