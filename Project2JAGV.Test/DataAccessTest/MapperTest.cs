using Microsoft.EntityFrameworkCore;
using Project2JAGV.DataAccess.Entities;
using Xunit;
using System.Linq;
using Project2JAGV.ObjectLogic;

namespace Project2JAGV.Test.DataAccessTest
{
    public class MapperTest
    {
        User user = new User()
        {
            Id = 1,
            Name = "UserName",
            Password = "Password",
            UserType = new UserType
            {
                Id = 1,
                Name = "Name"
            },
            Address = new Address()
            {
                Id = 0,
                Street = "Street",
                City = "City",
                State = "State",
                ZipCode = "ZipCode"
            }
        };

        [Fact]
        public async void AddUserShouldAddUser()
        {
            var options = new DbContextOptionsBuilder<Project2JAGVContext>()
                .UseInMemoryDatabase("AddUser")
                .Options;
            using var context = new Project2JAGVContext(options);

            var repo = new DataAccess.DataAccess(context);

            await repo.AddUserAsync(user);
            context.SaveChanges();

            using var assertContext = new Project2JAGVContext(options);
            var rest = assertContext.Users.Select(u => u);
            Assert.NotEmpty(rest);
        }
    }
}
