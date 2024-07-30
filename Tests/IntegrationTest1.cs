using Moq;
using MyFirstWebApiSite;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tests
{
    public class IntegrationTest1: IClassFixture<DatabaseFixture>
    {
        private readonly ClothesShop326023306Context _context;
        private readonly UserRepository _userRepository;

        public IntegrationTest1(DatabaseFixture dbf)
        {
            _context = dbf.Context;
            _userRepository = new UserRepository(_context);
        }

        [Fact]
        public async Task GetUser_ValidCredentials_ReurnsUser()
        {
            var email="async@a.a";
            var password = "aaaaaaaaaaa";
            var user = new User { UserName = "test@example.com", Password = "test1234" , FirstName="aaaaaaa", LastName="aaaaaaaa"};
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            var result = await _userRepository.getUserByEmailAndPassword(user.UserName, user.Password);

            Assert.NotNull(result);
        }


    }
}
