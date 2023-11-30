using MyFirstWebApiSite;
using Repositories;
using System.Text.Json;

namespace Services
{
    public class UserServices : IUserServices
    {
        IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        async public Task<User> getUserById(int id)
        {
            return await _userRepository.getUserById(id);
        }
         async public Task<User> addUserToDB(User user)
        {
            int result = validatePassword(user.Password);
            if (result < 2)
                return null;
            return await _userRepository.addUserToDB(user);
        }

        async public Task<User> getUserByEmailAndPassword(string email, string password)
        {
            return await _userRepository.getUserByEmailAndPassword(email, password);
        }

        async public Task<User> updateUserDetails(int id, User userToUpdate)
        {
            int result = validatePassword(userToUpdate.Password);
            if (result < 2)
                return null;
            return await _userRepository.updateUserDetails(id, userToUpdate);
            
        }

        public int validatePassword(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }
    }
}