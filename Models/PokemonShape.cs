using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models;

[Table("pokemon_shapes")]
public class PokemonShape
{
    [Column("id")]
    public int Id { get; set; }

    [Column("identifier")]
    public required string Identifier { get; set; }
}
