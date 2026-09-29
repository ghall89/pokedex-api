using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data;

public class PokedexDbContext : DbContext
{
    public PokedexDbContext(DbContextOptions<PokedexDbContext> options)
        : base(options)
    {
    }

    public DbSet<PokemonSpecies> PokemonSpecies { get; set; } = null!;
}
