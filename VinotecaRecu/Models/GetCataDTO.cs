using System.ComponentModel.DataAnnotations;
using VinotecaRecu.Data.Entities;

namespace VinotecaRecu.Models
{
    public class GetCataDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public List<int> WineIds { get; set; } = new List<int>();
        public List<string> Invitados { get; set; } = new List<string>();
    }
}
