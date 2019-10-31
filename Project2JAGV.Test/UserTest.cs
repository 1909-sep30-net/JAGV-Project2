using System;
using Xunit;

using Project2JAGV.ObjectLogic;

namespace Project2JAGV.Test
{
    public class UserTest
    {
        [Fact]
        public void User_Test()
        {
            Assert.Throws<ArgumentException>(() => new User { Id = -1 });
        }

        [Fact]
        public void User_Name_Empty()
        {
            Assert.Throws<ArgumentException>(() => new User { FirstName = "" });
        }
    }
}
