using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Repository
{
    public class UserRepository : BaseRopository, IUserRepository
    {
        public UserRepository(LibraryContext _context)
        {
            context = _context;
        }

        public async Task<RepositoryResponses> AddUser(User user)
        {
            if (context.Users.First(c => c.Username == user.Username) != null)
            {
                return RepositoryResponses.UsernameAlreadyTaken;
            }

            if (context.Users.First(c => c.Email == user.Email) != null)
            {
                return RepositoryResponses.EmailAlreadyRegistered;
            }

            if (context.Users.First(c => c.Phone == user.Phone) != null)
            {
                return RepositoryResponses.PhoneAlreadyRegistered;
            }

            var res = await context.AddAsync(user);

            if (res.State == EntityState.Added)
            {
                await context.SaveChangesAsync();
                return RepositoryResponses.Success;
            }
            return RepositoryResponses.UnknownError;
        }

        public async Task<EntityEntry<User>> DeleteUser(int id)
        {
            var user = await context.Users.FindAsync(id);

            var result = context.Users.Remove(user);
            await context.SaveChangesAsync();
            return result;
        }

        public async Task<User> GetUserById(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public async Task<User> GetUserByCredential(Credential credtential)
        {
            return await Task.Run(() => context.Users.First(c => c.Username == credtential.Username && c.Password == credtential.Password));
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await Task.Run(() => context.Users);
        }

        public async Task<EntityEntry<User>> UpdateUser(User user)
        {
            var result = context.Users.Update(user);
            await context.SaveChangesAsync();
            return result;
        }
    }
}
