using Entities;

namespace Repositories
{
    public interface IUserRepository
    {
        User addUserToDB(User user);
        Task<User> getUserByEmailAndPassword(string email, string password);
        Task<User> getUserById(int id);
        Task<bool> updateUserDetails(int id, User userToUpdate);
    }
}