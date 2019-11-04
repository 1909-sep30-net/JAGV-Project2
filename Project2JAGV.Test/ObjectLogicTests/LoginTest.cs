using Project2JAGV.ObjectLogic;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Project2JAGV.Test.ObjectLogicTests
{
    public class LoginTest
    {
        /// <summary>
        /// Testing for Empty Setters
        /// </summary>
        [Fact]
        public void Login_UserId_Empty()
        {
            Assert.Throws<ArgumentException>(() => new Login { UserId = -1 });
        }
        [Fact]
        public void Login_UserName_Empty()
        {
            Assert.Throws<ArgumentException>(() => new Login { UserName = "" });
        }
        [Fact]
        public void Login_UserPassword_Empty()
        {
            Assert.Throws<ArgumentException>(() => new Login { UserPassword = "" });
        }
        [Fact]
        public void Login_User_TypeId_Empty()
        {
            Assert.Throws<ArgumentException>(() => new Login { UserTypeId = -1 });
        }
        /// <summary>
        /// Login getters tests
        /// </summary>
        /// 
        readonly Login test_login = new Login();

        [Fact]
        public void Login_UserName_Get_Test()
        {
            Assert.ThrowsAny<ArgumentNullException>(() => test_login.UserName);
        }
        [Fact]
        public void Login_UserPassword_Get_Test()
        {
            Assert.ThrowsAny<ArgumentNullException>(() => test_login.UserPassword);
        }
        
    }
}
