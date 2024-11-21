using VinotecaRecu.Data.Entities;
using VinotecaRecu.Models;

namespace VinotecaRecu.Services.Interfaces
{
    public interface IUserService
    {
        void CreateUser(CreateUserDTO dto);
        User? ValidateUser(AuthDTO auth);
    }
}
