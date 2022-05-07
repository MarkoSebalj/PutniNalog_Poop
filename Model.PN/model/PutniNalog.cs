using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System;
using Model.PN.Model;

namespace Model.PN.Model
{
    [Table("putni_nalog")]
    public class PutniNalog:BaseEntity
    {
        [JsonPropertyName("datum_pocetka")]
        [Column("datum_pocetka")]
        public DateTime DatumPocetka { get; set; }

        [JsonPropertyName("datum_kraja")]
        [Column("datum_kraja")]
        public DateTime DatumKraja { get; set; }

        [JsonPropertyName("zaposlenik")]
        [Column("zaposlenik_id")]
        public int Zaposlenik { get; set; }

        [JsonPropertyName("mjesto_putovanja")]
        [Column("mjesto_putovanja_id")]
        public int MjestoPutovanja { get; set; }

        [JsonPropertyName("vozilo")]
        [Column("vozilo_id")]
        public int Vozilo { get; set; }

    }
}
