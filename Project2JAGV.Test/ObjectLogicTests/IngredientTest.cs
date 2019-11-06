using Project2JAGV.ObjectLogic;
using System;
using Xunit;

namespace Project2JAGV.Test.ObjectLogicTests
{
    public class IngredientTest
    {
        [Theory]
        [InlineData(-1, false)]
        [InlineData(1, true)]
        public void City_property_Test(int input, bool type)
        {
            if (!type)
            {
                Assert.Throws<ArgumentException>(() => new Ingredient { Id = input });
            }
            else
            {
                Ingredient test = new Ingredient();
                test.Id = input;
                Assert.Equal(input, test.Id);
            }
        }
        [Theory]
        [InlineData(-1, false)]
        [InlineData(1, true)]
        public void TypeId_property_Test(int input, bool type)
        {
            if (!type)
            {
                Assert.Throws<ArgumentException>(() => new Ingredient { TypeId = input });
            }
            else
            {
                Ingredient test = new Ingredient();
                test.TypeId = input;
                Assert.Equal(input, test.TypeId);
            }
        }
        [Theory]
        [InlineData("", false)]
        [InlineData("Name", true)]
        public void Name_property_Test(string input, bool type)
        {
            if (!type)
            {
                Assert.Throws<ArgumentException>(() => new Ingredient { Name = input });
            }
            else
            {
                Ingredient test = new Ingredient();
                test.Name = input;
                Assert.Equal(input, test.Name);
            }
        }
        [Theory]
        [InlineData(-1, false)]
        [InlineData(1, true)]
        public void Price_property_Test(int input, bool type)
        {
            if (!type)
            {
                Assert.Throws<ArgumentException>(() => new Ingredient { Price = input });
            }
            else
            {
                Ingredient test = new Ingredient();
                test.Price = input;
                Assert.Equal(input, test.Price);
            }
        }
    }
}
