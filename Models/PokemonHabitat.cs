using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models;

[Table("pokemon_habitats")]
public class PokemonHabitat
{
    [Column("id")]
    public int Id { get; set; }

    [Column("identifier")]
    public required string Identifier { get; set; }
}
