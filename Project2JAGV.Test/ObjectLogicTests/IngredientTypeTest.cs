using Project2JAGV.ObjectLogic;
using System;
using Xunit;

namespace Project2JAGV.Test.ObjectLogicTests
{
    public class IngredientTypeTest
    {
        [Theory]
        [InlineData(-1, false)]
        [InlineData(1, true)]
        public void Id_property_Test(int input, bool type)
        {

            if (!type)
            {
                Assert.Throws<ArgumentException>(() => new IngredientType { Id = input });
            }
            else
            {
                IngredientType test = new IngredientType();
                test.Id = input;
                Assert.Equal(input, test.Id);
            }
        }
        [Theory]
        [InlineData("", false)]
        [InlineData("name", true)]
        public void Name_property_Test(string input, bool type)
        {

            if (!type)
            {
                Assert.Throws<ArgumentException>(() => new IngredientType { Name = input });
            }
            else
            {
                IngredientType test = new IngredientType();
                test.Name = input;
                Assert.Equal(input, test.Name);
            }
        }
    }


}
