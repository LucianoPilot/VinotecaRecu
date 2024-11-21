using VinotecaRecu.Models;

namespace VinotecaRecu.Services.Interfaces
{
    public interface IWineService
    {
        void CreateWine(CreateWineDTO dto);
        List<GetWineDTO> GetAllWine();
        List<GetStockDTO> GetStockByVariety(string variety);
        void UpdateWineStock(int wineId, UpdateWineStockDTO dto);
    }
}
