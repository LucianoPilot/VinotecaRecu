using VinotecaRecu.Data.Entities;
using VinotecaRecu.Data.Interfaces;
using VinotecaRecu.Data.Repositories;
using VinotecaRecu.Models;

namespace VinotecaRecu.Services
{
    public class CataService
    {
        private readonly IWineRepository _wineRepository;
        private readonly ICataRepository _cataRepository;

        public CataService(IWineRepository wineRepository, ICataRepository cataRepository)
        {
            _cataRepository = cataRepository;
            _wineRepository = wineRepository;

        }
             public async Task CreateCata(CreateCataDTO dto)
             {
            var wines = await _wineRepository.GetByIdsAsync(dto.WineIds);
            if (wines == null || wines.Count == 0)
                throw new Exception("No se encontraron vinos con los IDs proporcionados.");

            var newCata = new Cata
            {
                Fecha = dto.Fecha,
                Name = dto.Name,
                Wines = wines.ToList(), // Asociar las entidades de vino
                Invitados = dto.Invitados
            };
            await _cataRepository.AddAsync(newCata);
        }


        public List<GetCataDTO> GetAllCata()
        {
            var catas = _cataRepository.GetAll();
            return catas.Select(cata => new GetCataDTO
            {
                Fecha = cata.Fecha,
                Name = cata.Name,
                WineIds = cata.WineIds,
                Invitados = cata.Invitados,

            }).ToList();
        }

public void UpdateInvitados(int cataId, List<string> nuevosInvitados)
{
    if (nuevosInvitados == null || !nuevosInvitados.Any())
    {
        throw new ArgumentException("La lista de invitados no puede estar vacía.", nameof(nuevosInvitados));
    }

    _cataRepository.UpdateInvitados(cataId, nuevosInvitados);
}


    }
}
