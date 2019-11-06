using Project2JAGV.ObjectLogic;
using System;
using Xunit;

namespace Project2JAGV.Test.ObjectLogicTests
{
    public class AddressTest
    {
        [Theory]
        [InlineData(-1, false)]
        [InlineData(1, true)]
        public void Id_property_Test(int input, bool type)
        {
            if (!type)
            {
                Assert.Throws<ArgumentException>(() => new Address { Id = input });
            }
            else
            {
                Address test = new Address();
                test.Id = input;
                Assert.Equal(input, test.Id);
            }
        }

        [Theory]
        [InlineData("", false)]
        [InlineData("Street", true)]
        public void Street_property_Test(string input, bool type)
        {
            if (!type)
            {
                Assert.Throws<ArgumentException>(() => new Address { Street = input });
            }
            else
            {
                Address test = new Address();
                test.Street = input;
                Assert.Equal(input, test.Street);
            }
        }
        [Theory]
        [InlineData("", false)]
        [InlineData("City", true)]
        public void City_property_Test(string input, bool type)
        {
            if (!type)
            {
                Assert.Throws<ArgumentException>(() => new Address { City = input });
            }
            else
            {
                Address test = new Address();
                test.City = input;
                Assert.Equal(input, test.City);
            }
        }
        [Theory]
        [InlineData("", false)]
        [InlineData("State", true)]
        public void State_property_Test(string input, bool type)
        {
            if (!type)
            {
                Assert.Throws<ArgumentException>(() => new Address { State = input });
            }
            else
            {
                Address test = new Address();
                test.State = input;
                Assert.Equal(input, test.State);
            }
        }
        [Theory]
        [InlineData("", false)]
        [InlineData("ZipCode", true)]
        public void ZipCode_property_Test(string input, bool type)
        {
            if (!type)
            {
                Assert.Throws<ArgumentException>(() => new Address { ZipCode = input });
            }
            else
            {
                Address test = new Address();
                test.ZipCode = input;
                Assert.Equal(input, test.ZipCode);
            }
        }

    }
}
