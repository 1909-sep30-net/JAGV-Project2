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
        public void Ingredient_Id_Test()
        {
            Assert.Throws<ArgumentException>(() => new Ingredient { Id = -1 });

        }

        [Fact]
        public void Ingredient_Type_Id_Test()
        {
            Assert.Throws<ArgumentException>(() => new Ingredient { TypeId = -1 });
        }

        [Fact]
        public void Ingredient_Name_Empty()
        {
            Assert.Throws<ArgumentException>(() => new Ingredient { Name = "" });
        }

        [Fact]
        public void Ingredient_Price_Test()
        {
            Assert.Throws<ArgumentException>(() => new Ingredient { Price = -1 });
        }
    }
}
