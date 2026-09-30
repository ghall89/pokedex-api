using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models;

[Table("pokemon")]
public class Pokemon
{
    [Column("id")]
    public int Id { get; set; }

    [Column("species_id")]
    public int? SpeciesId { get; set; }

    [Column("height")]
    public int Height { get; set; }

    [Column("weight")]
    public int Weight { get; set; }

    [Column("base_experience")]
    public int BaseExperience { get; set; }

    [Column("order")]
    public int Order { get; set; }

    [Column("is_default")]
    public bool IsDefault { get; set; }
}
