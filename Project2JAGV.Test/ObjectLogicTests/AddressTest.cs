using Project2JAGV.ObjectLogic;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Project2JAGV.Test.ObjectLogicTests
{
    public class AddressTest
    {
        [Fact]
        public void Address_Id_Test()
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

    }
}
