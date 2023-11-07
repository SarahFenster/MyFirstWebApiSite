//using Entities;
using Microsoft.EntityFrameworkCore;
using MyFirstWebApiSite;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ClothesShop326023306Context _clothesShop326023306Context;

        public UserRepository(ClothesShop326023306Context clothesShop326023306Context)
        {
            _clothesShop326023306Context = clothesShop326023306Context;
        }
        
         public async Task<User> addUserToDB(User user)
        {
            await _clothesShop326023306Context.Users.AddAsync(user);
            await _clothesShop326023306Context.SaveChangesAsync();
            return user;
        }
        async public Task<User> getUserById(int id)
        {
            return await _clothesShop326023306Context.Users.Where(user=>user.Id==id).FirstOrDefaultAsync();
        }
        async public Task<User> getUserByEmailAndPassword(string email, string password)
        {
            return await _clothesShop326023306Context.Users.Where(user=>user.UserName==email&&user.Password==password).FirstOrDefaultAsync();

        }
        async public Task<User> updateUserDetails(int id, User userToUpdate)
        {
             var res= _clothesShop326023306Context.Users.Update(userToUpdate);
            await _clothesShop326023306Context.SaveChangesAsync();
           
            return res!=null? userToUpdate:null ;

        }

    }
}