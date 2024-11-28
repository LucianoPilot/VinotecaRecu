using VinotecaRecu.Models;

namespace VinotecaRecu.Models
{
    public class CataDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public List<WineDTO> Wines { get; set; }
    }
}
