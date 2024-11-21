using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VinotecaRecu.Data.Entities
{
    public class Cata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Name { get; set; }
        public List<int> WineIds { get; set; } = new List<int>();
        public List<string> Invitados { get; set; } = new List<string>();
        public ICollection<Wine> Wines { get; set; } = new List<Wine>();
    }
}
