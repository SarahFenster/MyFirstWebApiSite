//using Entities;
using MyFirstWebApiSite;

namespace Services
{
    public interface IUserServices
    {
        Task<User> addUserToDB(User user);
        Task<User> getUserByEmailAndPassword(string email, string password);
        Task<User> getUserById(int id);
        Task<User> updateUserDetails(int id, User userToUpdate);
        int validatePassword(string password);
    }
}