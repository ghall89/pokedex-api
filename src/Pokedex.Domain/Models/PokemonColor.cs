using System.ComponentModel.DataAnnotations.Schema;

namespace Pokedex.Domain.Models;

[Table("pokemon_colors")]
public class PokemonColor
{
    [Column("id")]
    public int Id { get; set; }

    [Column("identifier")]
    public required string Identifier { get; set; }
}
