using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Project2JAGV.ObjectLogic;

namespace Project2JAGV.Test.ObjectLogicTests
{
    public class PizzaTest
    {
        /// <summary>
        /// Testing for Empty Setters
        /// </summary>
        [Fact]
        public void Pizza_Negative_Id()
        {
            Assert.Throws<ArgumentException>(() => new Pizza { Id = -1 });
        }
        
        [Fact]
        public void Pizza_Name_Empty()
        {
            Assert.Throws<ArgumentException>(() => new Pizza { Name = "" });
        }
        /// <summary>
        /// Testing Getters
        /// </summary>

        Pizza test_pizza = new Pizza();

        [Fact]
        public void Pizza_Name_Get_Test()
        {
            Assert.Throws<ArgumentNullException>(() => test_pizza.Name );
        }

    }
}
