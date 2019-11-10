using System;
using Xunit;
using Project2JAGV.ObjectLogic;

namespace Project2JAGV.Test.ObjectLogicTests
{
    public class PizzaIngredientTest
    {
        [Theory]
        [InlineData(-1, false)]
        [InlineData(1, true)]
        public void Id_property_Test(int input, bool type)
        {
            if (!type)
            {
                Assert.Throws<ArgumentException>(() => new PizzaIngredient { Id = input });
            }
            else
            {
                PizzaIngredient test = new PizzaIngredient();
                test.Id = input;
                Assert.Equal(input, test.Id);
            }
        }
        [Theory]
        [InlineData(-1, false)]
        [InlineData(1, true)]
        public void PizzaId_property_Test(int input, bool type)
        {
            if (!type)
            {
                Assert.Throws<ArgumentException>(() => new PizzaIngredient { PizzaId = input });
            }
            else
            {
                PizzaIngredient test = new PizzaIngredient();
                test.PizzaId = input;
                Assert.Equal(input, test.PizzaId);
            }
        }
        [Theory]
        [InlineData(-1, false)]
        [InlineData(1, true)]
        public void IngredientId_property_Test(int input, bool type)
        {
            if (!type)
            {
                Assert.Throws<ArgumentException>(() => new PizzaIngredient { IngredientId = input });
            }
            else
            {
                PizzaIngredient test = new PizzaIngredient();
                test.IngredientId = input;
                Assert.Equal(input, test.IngredientId);
            }
        }

    }
}
