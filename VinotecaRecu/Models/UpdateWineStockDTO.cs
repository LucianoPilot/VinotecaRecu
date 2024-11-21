using System.ComponentModel.DataAnnotations;

namespace VinotecaRecu.Models
{
    public class UpdateWineStockDTO
    {

        [Range(0, int.MaxValue, ErrorMessage = "El stock debe ser mayor o igual a 0.")]
        public int Stock { get; set; }
    }
}
