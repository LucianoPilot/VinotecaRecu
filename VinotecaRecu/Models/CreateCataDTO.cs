using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VinotecaRecu.Data.Entities;

namespace VinotecaRecu.Models
{
    public class CreateCataDTO
    {

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        [Required]
        public string Name { get; set; }
        public List<int> WineIds { get; set; } = new List<int>();
        public List<string> Invitados { get; set; } = new List<string>();
        //public List<int> WineIds { get; set; }
    }
}
