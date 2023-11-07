
using MyFirstWebApiSite;
//using Entities;

namespace Repositories
{
    public interface IUserRepository
    {
        Task<User> addUserToDB(User user);
        Task<User> getUserByEmailAndPassword(string email, string password);
        Task<User> getUserById(int id);
        Task<User> updateUserDetails(int id, User userToUpdate);
    }
}