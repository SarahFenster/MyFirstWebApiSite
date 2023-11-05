﻿using Entities;
using Repositories;
using System.Text.Json;



namespace Services
{
    public class UserServices : IUserServices
    {
        IUserRepository userRepository;

        public UserServices(IUserRepository iuserRepository)
        {
            //IUserRepository userRepository (instead of  iuserService)
            userRepository = iuserRepository;
        }

        async public Task<User> getUserById(int id)
        {
            return await userRepository.getUserById(id);
        }
        //Function name- addUser/ createUser (This function doesn't add the userToDB...)-clean code
         public User addUserToDB(User user)
        {
            //async await??? 
            int result = validatePassword(user.Password);
            if (result < 2)
                return null;
            return userRepository.addUserToDB(user);
        }

        async public Task<User> getUserByEmailAndPassword(string email, string password)
        {
            return await userRepository.getUserByEmailAndPassword(email, password);
        }

        async public Task<int> updateUserDetails(int id, User userToUpdate)
        {
            //Why do you return numbers? Why not return null if password isn't strong, else return userRepository.update(...)?
            int result = validatePassword(userToUpdate.Password);
            if (result < 2)
                return 1;
            bool res = await userRepository.updateUserDetails(id, userToUpdate);
            if (res)
                return 0;
            return 2;
        }

        public int validatePassword(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }
    }
}