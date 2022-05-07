using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Model.PN.Model;

namespace Model.PN.Model
{
    [Table("radno_mjesto")]
    public class RadnoMjesto:BaseEntity
    {
        [JsonPropertyName("naziv")]
        [Column("naziv")]
        public string? Naziv { get; set; }

    }
}
