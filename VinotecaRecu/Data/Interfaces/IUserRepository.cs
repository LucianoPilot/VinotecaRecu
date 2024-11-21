using VinotecaRecu.Data.Entities;

namespace VinotecaRecu.Data.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User? GetUserByUsernameAndPassword(string UserName, string Password);
    }
}
