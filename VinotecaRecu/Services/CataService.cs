using VinotecaRecu.Data.Entities;
using VinotecaRecu.Data.Interfaces;
using VinotecaRecu.Data.Repositories;
using VinotecaRecu.Models;
using Microsoft.EntityFrameworkCore;

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
            // Recupera los vinos basándote en los IDs proporcionados
            var wines = await _wineRepository.GetByIdsAsync(dto.WineIds);

            if (wines == null || !wines.Any())
                throw new Exception("No se encontraron vinos con los IDs proporcionados.");

            var newCata = new Cata
            {
                Fecha = dto.Fecha,
                Name = dto.Name,
                Wines = wines.ToList(), // Asocia los vinos a la nueva cata
                Invitados = dto.Invitados
            };

            await _cataRepository.AddAsync(newCata); // Guarda la cata con las relaciones
        }



        public List<GetCataDTO> GetAllCata()
        {
            var catas = _cataRepository.GetAll()
                .Include(c => c.Wines) // Asegura que las relaciones se carguen
                .ToList();

            return catas.Select(cata => new GetCataDTO
            {
                Fecha = cata.Fecha,
                Name = cata.Name,
                WineIds = cata.Wines.Select(w => w.Id).ToList(), // Deriva los IDs de los vinos
                Invitados = cata.Invitados
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
