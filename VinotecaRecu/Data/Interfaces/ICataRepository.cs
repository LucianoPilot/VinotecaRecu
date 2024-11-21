using VinotecaRecu.Data.Entities;

namespace VinotecaRecu.Data.Interfaces
{
    public interface ICataRepository
    {
        void Add(Cata cata);
        Cata GetById(int id);
        IEnumerable<Cata> GetAll();
        Task AddAsync(Cata cata);
        void UpdateInvitados(int cataId, List<string> nuevosInvitados);
    }

}
