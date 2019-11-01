using Project2JAGV.ObjectLogic;
using System;
using Xunit;

namespace Project2JAGV.Test.ObjectLogicTests
{
    public class IngredientTest
    {
        [Fact]
        public void Ingredient_Negative_Id()
        {
            Assert.Throws<ArgumentException>(() => new Ingredient { Id = -1 });
        }
        [Fact]
        public void Ingredient_Negative_Type_Id()
        {
            Assert.Throws<ArgumentException>(() => new Ingredient { TypeId = -1 });
        }
        [Fact]
        public void Ingredient_Name_Empty()
        {
            Assert.Throws<ArgumentException>(() => new Ingredient { Name = "" });
        }
        [Fact]
        public void Ingredient_Negative_Price()
        {
            Assert.Throws<ArgumentException>(() => new Ingredient { Price = -1.20m });
        }
        /// <summary>
        /// Ingredient getters tests
        /// </summary>
        readonly Ingredient test_ingredient = new Ingredient();

        [Fact]
        public void Ingredient_typeId_Get_Test()
        {
            Assert.ThrowsAny<ArgumentException>(() => test_ingredient.TypeId);
        }
        [Fact]
        public void Ingredient_Name_Get_Test()
        {
            Assert.ThrowsAny<ArgumentNullException>(() => test_ingredient.Name);
        }
        [Fact]
        public void Ingredient_Price_Get_Test()
        {
            Assert.ThrowsAny<ArgumentException>(() => test_ingredient.Price);
        }

        IngredientType test_type = new IngredientType();

        [Fact]
        public void Ingredient_Type_Name_Get_Test()
        {
            Assert.ThrowsAny<ArgumentNullException>(() => test_type.Name);
        }

    }
}
