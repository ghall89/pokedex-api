using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models;

[Table("pokemon_species")]
public class PokemonSpecies
{
    [Column("id")]
    public int Id { get; set; }

    [Column("identifier")]
    public required string Identifier { get; set; }

    [Column("generation_id")]
    public int? GenerationId { get; set; }

    [Column("evolves_from_species_id")]
    public int? EvolvesFromSpeciesId { get; set; }

    [Column("evolution_chain_id")]
    public int? EvolutionChainId { get; set; }

    [Column("color_id")]
    public int ColorId { get; set; }

    [Column("shape_id")]
    public int ShapeId { get; set; }

    [Column("habitat_id")]
    public int? HabitatId { get; set; }

    [Column("gender_rate")]
    public int GenderRate { get; set; }

    [Column("capture_rate")]
    public int CaptureRate { get; set; }

    [Column("base_happiness")]
    public int BaseHappiness { get; set; }

    [Column("is_baby")]
    public bool IsBaby { get; set; }

    [Column("hatch_counter")]
    public int HatchCounter { get; set; }

    [Column("has_gender_differences")]
    public bool HasGenderDifferences { get; set; }

    [Column("growth_rate_id")]
    public int GrowthRateId { get; set; }

    [Column("forms_switchable")]
    public bool FormsSwitchable { get; set; }

    [Column("order")]
    public int Order { get; set; }

    [Column("conquest_order")]
    public int? ConquestOrder { get; set; }
}
