using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model.PN.Model
{
    [Table("vrsta_troska")]
    public class VrstaTroska:BaseEntity
    {
        [JsonPropertyName("naziv")]
        [Column("naziv")]
        public string? Naziv { get; set; }
    }
}
