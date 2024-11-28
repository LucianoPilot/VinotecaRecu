using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using VinotecaRecu.Data.Entities;
using VinotecaRecu.Data.Interfaces;

namespace VinotecaRecu.Data.Repositories
{
    public class CataRepository : ICataRepository
    {
        private readonly VinotecaRecuContext _context;
        public CataRepository(VinotecaRecuContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Cata cata)
        {
            await _context.Catas.AddAsync(cata);
            await _context.SaveChangesAsync();
        }
        public void Add(Cata cata)
       {
            _context.Catas.Add(cata);
            _context.SaveChangesAsync();
        }


        public Cata GetById(int id)
        {
            return _context.Catas.Include(c => c.Wines).FirstOrDefault(c => c.Id == id);
        }
        public IQueryable<Cata> GetAll()
        {
            return _context.Catas.AsQueryable();
        }


        public void UpdateInvitados(int cataId, List<string> nuevosInvitados)
        {
            var existingCata = _context.Catas.FirstOrDefault(c => c.Id == cataId);
            if (existingCata != null)
            {
                existingCata.Invitados = nuevosInvitados;
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"La cata con ID {cataId} no fue encontrada.");
            }
        }



    }
}
