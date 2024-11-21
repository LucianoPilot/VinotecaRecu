using System.ComponentModel.DataAnnotations;

namespace VinotecaRecu.Models
{
    public class CreateWineDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public string Variety { get; set; } = string.Empty;

        [Range(1860, 2024, ErrorMessage = "El año de cosecha debe estar entre 1860 y el año actual.")]
        public int Year { get; set; }

        public string Region { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "El stock debe ser mayor o igual a 0.")]
        public int Stock { get; set; }
    }
}
