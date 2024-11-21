using VinotecaRecu.Data.Entities;

namespace VinotecaRecu.Data.Interfaces
{
    public interface IWineRepository
    {

        void AddWine(Wine wine);
        List<Wine> GetAllWines();
        List<Wine> GetStockByVariety(string variety);
        void UpdateWineStock(int wineId, int stock);
        Task<List<Wine>> GetByIdsAsync(List<int> wineIds);
    }
}
