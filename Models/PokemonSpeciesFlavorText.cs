using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Models;

[Table("pokemon_species_flavor_text")]
[PrimaryKey(nameof(SpeciesId), nameof(VersionId), nameof(LanguageId))]
public class PokemonSpeciesFlavorText
{
    [Column("species_id")]
    public int SpeciesId { get; set; }

    [Column("version_id")]
    public int VersionId { get; set; }

    [Column("language_id")]
    public int LanguageId { get; set; }

    [Column("flavor_text")]
    public required string FlavorText { get; set; }
}
