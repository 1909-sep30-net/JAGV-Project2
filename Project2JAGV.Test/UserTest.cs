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
            Assert.Throws<ArgumentException>(() => new Users { Id = -1 });
        }
    }
}
