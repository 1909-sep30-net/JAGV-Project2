using Microsoft.EntityFrameworkCore;
using Project2JAGV.DataAccess.Entities;
using Xunit;
using System.Linq;
using Project2JAGV.DataAccess;
using System.Threading.Tasks;
using System.Collections.Generic;
using Project2JAGV.ObjectLogic;

namespace Project2JAGV.Test.DataAccessTest
{
    public class MapperTest
    {
        /// <summary>

        /// Testing if creators are added to database

        /// </summary>
        /// 

        ObjectLogic.User user = new ObjectLogic.User()

        {

            FirstName = "Emily",

            LastName = "Smith",

            Id = 99,

            Login = new ObjectLogic.Login()
            {
                UserId = 0,
                UserName = "a",
                UserPassword = "a",
                UserType = new ObjectLogic.UserType() { Id = 0, Name = "a" },
                UserTypeId = 0
            },

            Address = new ObjectLogic.Address()
            {
                Id = 0,
                Street = "a",
                City = "a",
                State = "a",
                ZipCode = "a"
            }
        };

        [Fact]

        public async void AddUserShouldAddUser()

        {

            //arrange

            var options = new DbContextOptionsBuilder<Project2JAGVContext>()

                .UseInMemoryDatabase("AddUser")

                .Options;



            using var context = new Project2JAGVContext(options);

            var repo = new DataAccess.DataAccess(context);


            //act

            await repo.AddUserAsync(user);

            context.SaveChanges();


            //assert

            using var assertContext = new Project2JAGVContext(options);

            var rest = assertContext.Users.Select(u => u);

            Assert.NotEmpty(rest);

        }

        //[Fact]

        //public async void GetUsersShoulGetUsers()

        //{

        //    //arrange

        //    var options = new DbContextOptionsBuilder<Project2JAGVContext>()

        //        .UseInMemoryDatabase("AddUser2")

        //        .Options;



        //    using var context = new Project2JAGVContext(options);

        //    var repo = new DataAccess.DataAccess(context);




        //    //act

        //    await repo.AddUserAsync(user);

        //    context.SaveChanges();

            




        //    //assert

        //    using var assertContext = new Project2JAGVContext(options);

        //    var entity = assertContext.Users
        //        .Include(u => u.Address)
        //        .Include(u => u.Login)
        //            .ThenInclude(l => l.UserType)
        //        .First();

        //    User nerd = Mappers.MapUser(entity);


        //    Assert.Equal(user, nerd);

        //}

    }
}
