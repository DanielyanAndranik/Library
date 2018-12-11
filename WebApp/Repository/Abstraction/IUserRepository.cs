using WebApp.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();

        Task<User> GetUserById(int id);

        Task<User> GetUserByCredential(Credential credtential);

        Task<RepositoryResponses> AddUser(User user);

        Task<EntityEntry<User>> UpdateUser(User user);

        Task<EntityEntry<User>> DeleteUser(int id);
    }
}
