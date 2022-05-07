using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Model.PN.Model;

namespace Model.PN.Model
{
    [Table("vozilo")]
    public class Vozilo:BaseEntity

    {
        [JsonPropertyName("marka")]
        [Column("marka")]
        public string? Marka { get; set; }



        [JsonPropertyName("registracija")]
        [Column("registracija")]
        public string? Registracija { get; set; }

    }
}
