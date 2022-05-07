using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model.PN.Model
{
    [Table("zaposlenik")]
    public class Zaposlenik:BaseEntity
    {
        [JsonPropertyName("ime")]
        [Column("ime")]
        public string? Ime { get; set; }

        [JsonPropertyName("prezime")]
        [Column("prezime")]
        public string? Prezime { get; set; }

        [JsonPropertyName("ukupni_iznos_troska")]
        [Column("ukupni_iznos_troska")]
        public double? UkupniIznosTroska { get; set; }

        [JsonPropertyName("radno_mjesto")]
        [Column("radno_mjesto_id")]
        public int RadnoMjesto { get; set; }

        [JsonPropertyName("putni_troskovi")]
        [Column("putni_troskovi_id")]
        public int PutniTroskovi { get; set; }
    }
}
