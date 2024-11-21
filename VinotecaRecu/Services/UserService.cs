using VinotecaRecu.Data.Entities;
using VinotecaRecu.Data.Interfaces;
using VinotecaRecu.Models;
using VinotecaRecu.Services.Interfaces;

namespace VinotecaRecu.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void CreateUser(CreateUserDTO dto)
        {
            User newUser = new User()
            {
                Username = dto.Username,
                Password = dto.Password,
            };
            _userRepository.AddUser(newUser);
        }
        public User? ValidateUser(AuthDTO auth)
        {
            return _userRepository.GetUserByUsernameAndPassword(auth.Username, auth.Password);
        }

    }
}
