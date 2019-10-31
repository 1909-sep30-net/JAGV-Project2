using Project2JAGV.ObjectLogic;
using System;
using System.Collections.Generic;
using System.Text;
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
            Assert.Throws<ArgumentException>(() => new Ingredient { Price = -1 });
        }
    }
}
