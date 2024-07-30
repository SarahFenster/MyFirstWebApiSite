using Moq;
using Moq.EntityFrameworkCore;
using MyFirstWebApiSite;
using Repositories;

namespace Tests
{
    
    public class UnitTest1
    {
        [Fact]
        public async Task GetUser_ValidCredentials_ReurnsUser()
        {
            var user = new User { UserName = "test@example.com", Password = "test1234" };

            var mockContext = new Mock<ClothesShop326023306Context>();
            var users = new List<User>() { user };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);

            var userRepository = new UserRepository(mockContext.Object);

            var result = await userRepository.getUserByEmailAndPassword(user.UserName, user.Password);

            Assert.Equal(user, result);
        }
    }
}
