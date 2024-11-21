using Microsoft.EntityFrameworkCore;
using VinotecaRecu.Data.Entities;
using VinotecaRecu.Data.Interfaces;

namespace VinotecaRecu.Data.Repositories
{
    public class WineRepository : IWineRepository
    {
        private readonly VinotecaRecuContext _context;
        public WineRepository(VinotecaRecuContext context)
        {
            _context = context;
        }
        public void AddWine(Wine wine)
        {
            _context.Wines.Add(wine);
            _context.SaveChangesAsync();
        }

        public List<Wine> GetAllWines()
        {
            return _context.Wines.ToList();
        }

        public List<Wine> GetStockByVariety(string variety)
        {
            return _context.Wines
                .Where(w => w.Variety.ToLower() == variety.ToLower() && w.Stock > 0)
                .ToList();
        }
        public void UpdateWineStock(int wineId, int stock)
        {
            var wineToUpdate = _context.Wines.FirstOrDefault(w => w.Id == wineId);

            if (wineToUpdate == null)
                throw new Exception("Vino no encontrado");

            wineToUpdate.Stock = stock;
            _context.SaveChanges();
        }

        public async Task<List<Wine>> GetByIdsAsync(List<int> wineIds)
        {
            var wines = await _context.Wines
                .Where(w => wineIds.Contains(w.Id)) 
                .ToListAsync();

            return wines;
        }

    }
}