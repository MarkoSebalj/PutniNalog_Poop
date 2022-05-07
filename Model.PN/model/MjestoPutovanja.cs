using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Model.PN.Model;

namespace Model.PN.Model
{
    [Table("mjesto_putovanja")]
    public class MjestoPutovanja:BaseEntity
    {
        [JsonPropertyName("naziv_mjesta")]
        [Column("naziv_mjesta")]
        public string? NazivMjesta { get; set; }
    }
}
