
using MyFirstWebApiSite;
//using Entities;

namespace Repositories
{
    public interface IUserRepository
    {
        Task<User> addUserToDB(User user);
        Task<User> getUserByEmailAndPassword(string email, string password);
        Task<User> getUserById(int id);
        Task<bool> updateUserDetails(int id, User userToUpdate);
    }
}