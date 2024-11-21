using VinotecaRecu.Data.Entities;
using VinotecaRecu.Data.Interfaces;
using VinotecaRecu.Models;
using VinotecaRecu.Services.Interfaces;

namespace VinotecaRecu.Services
{
    public class WineService : IWineService
    {
        private readonly IWineRepository _wineRepository;
        public WineService(IWineRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }


        public void CreateWine(CreateWineDTO dto)
        {
            Wine newWine = new Wine()
            {
                Name = dto.Name,
                Variety = dto.Variety,
                Region = dto.Region,
                Stock = dto.Stock,
                Year = dto.Year
            };

            _wineRepository.AddWine(newWine);
        }

        public List<GetWineDTO> GetAllWine()
        {
            var wines = _wineRepository.GetAllWines();
            return wines.Select(wine => new GetWineDTO
            {
                Name = wine.Name,
                Variety = wine.Variety,
                Year = wine.Year,
                Region = wine.Region,
                Stock = wine.Stock

            }).ToList();
        }

        public List<GetStockDTO> GetStockByVariety(string variety)
        {

            var wines = _wineRepository.GetStockByVariety(variety);


            var stockByVariety = wines
                .GroupBy(wine => wine.Variety)
                .Select(group => new GetStockDTO
                {
                    Variety = group.Key,
                    Stock = group.Sum(wine => wine.Stock)
                })
        .ToList();

            return stockByVariety;
        }
        public void UpdateWineStock(int wineId, UpdateWineStockDTO dto)
        {
            if (dto.Stock < 0)
                throw new ArgumentException("El stock debe ser mayor a -1");

            _wineRepository.UpdateWineStock(wineId, dto.Stock);
        }
    }
}