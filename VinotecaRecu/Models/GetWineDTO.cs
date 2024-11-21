using System.ComponentModel.DataAnnotations;

namespace VinotecaRecu.Models
{
    public class GetWineDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Range(0, int.MaxValue, ErrorMessage = "El stock de los vinos tiene que ser mayor o igual a 0.")]
        public int Stock { get; set; }
        public string Variety { get; set; } = string.Empty;

        [Range(1860, 2024, ErrorMessage = "El año de cosecha debe ser entre 1860 y 2024.")]
        public int Year { get; set; }

        public string Region { get; set; } = string.Empty;
    }
}
