using VinotecaRecu.Data.Entities;
using VinotecaRecu.Data.Interfaces;

namespace VinotecaRecu.Data.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly VinotecaRecuContext _context;

        public UserRepository(VinotecaRecuContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.AddAsync(user);
            _context.SaveChangesAsync();
        }

        public User? GetUserByUsernameAndPassword(string username, string password)
        {
            return _context.Users.FirstOrDefault(p => p.Username == username && p.Password == password);
        }

        public User? Authenticate(string username, string password)
        {

            User? userToAuthenticate = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            return userToAuthenticate;

        }
    }
}
