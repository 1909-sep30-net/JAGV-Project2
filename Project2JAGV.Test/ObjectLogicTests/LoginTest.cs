using Project2JAGV.ObjectLogic;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Project2JAGV.Test.ObjectLogicTests
{
    public class LoginTest
    {
        [Theory]
        [InlineData("", false)]
        [InlineData("UserName", true)]
        public void UsserName_property_Test(string input, bool type)
        {
            if (!type)
            {
                Assert.Throws<ArgumentException>(() => new Login { UserName = input });
            }
            else
            {
                Login test = new Login();
                test.UserName = input;
                Assert.Equal(input, test.UserName);
            }
        }
        [Theory]
        [InlineData("", false)]
        [InlineData("UserPassword", true)]
        public void UsserPassword_property_Test(string input, bool type)
        {
            if (!type)
            {
                Assert.Throws<ArgumentException>(() => new Login { UserPassword = input });
            }
            else
            {
                Login test = new Login();
                test.UserPassword = input;
                Assert.Equal(input, test.UserPassword);
            }
        }
        [Theory]
        [InlineData(-1, false)]
        [InlineData(1, true)]
        public void UsserId_property_Test(int input, bool type)
        {
            if (!type)
            {
                Assert.Throws<ArgumentException>(() => new Login { UserId = input });
            }
            else
            {
                Login test = new Login();
                test.UserId = input;
                Assert.Equal(input, test.UserId);
            }
        }
        [Theory]
        [InlineData(-1, false)]
        [InlineData(1, true)]
        public void UserTypeId_property_Test(int input, bool type)
        {
            if (!type)
            {
                Assert.Throws<ArgumentException>(() => new Login { UserTypeId = input });
            }
            else
            {
                Login test = new Login();
                test.UserTypeId = input;
                Assert.Equal(input, test.UserTypeId);
            }
        }
    }
}
