using Project2JAGV.ObjectLogic;
using System;
using Xunit;

namespace Project2JAGV.Test.ObjectLogicTests
{
    public class AddressTest
    {
        /// <summary>
        /// Testing for Empty Setters
        /// </summary>
        [Fact]
        public void Address_Id_Empty()
        {
            Assert.Throws<ArgumentException>(() => new Address { Id = -1 });
        }
        [Fact]
        public void Address_Street_Empty()
        {
            Assert.Throws<ArgumentException>(() => new Address { Street = "" });
        }
        [Fact]
        public void Address_State_Empty()
        {
            Assert.Throws<ArgumentException>(() => new Address { State = "" });
        }
        [Fact]
        public void Address_ZipCode_Empty()
        {
            Assert.Throws<ArgumentException>(() => new Address { ZipCode = "" });
        }
        [Fact]
        public void Address_City_Empty()
        {
            Assert.Throws<ArgumentException>(() => new Address { City = "" });
        }

        /// <summary>
        /// Testing for Empty Getters
        /// </summary>
        readonly Address test_address = new Address();

        [Fact]
        public void Address_Street_Get_Test()
        {
            Assert.ThrowsAny<ArgumentNullException>(() => test_address.Street);
        }
        [Fact]
        public void Address_State_Get_Test()
        {
            Assert.ThrowsAny<ArgumentNullException>(() => test_address.State);
        }
        [Fact]
        public void Address_Zip_Get_Test()
        {
            Assert.ThrowsAny<ArgumentNullException>(() => test_address.ZipCode);
        }
        [Fact]
        public void Address_City_Get_Test()
        {
            Assert.ThrowsAny<ArgumentNullException>(() => test_address.City);
        }
    }
}
