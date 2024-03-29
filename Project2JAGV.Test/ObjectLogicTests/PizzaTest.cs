﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Project2JAGV.ObjectLogic;

namespace Project2JAGV.Test.ObjectLogicTests
{
    public class PizzaTest
    {
        [Theory]
        [InlineData(-1, false)]
        [InlineData(1, true)]
        public void Id_property_Test(int input, bool type)
        {
            if (!type)
            {
                Assert.Throws<ArgumentException>(() => new Pizza { Id = input });
            }
            else
            {
                Pizza test = new Pizza();
                test.Id = input;
                Assert.Equal(input, test.Id);
            }
        }
        [Theory]
        [InlineData("", false)]
        [InlineData("Name", true)]
        public void Name_property_Test(string input, bool type)
        {
            if (!type)
            {
                Assert.Throws<ArgumentException>(() => new Pizza { Name = input });
            }
            else
            {
                Pizza test = new Pizza();
                test.Name = input;
                Assert.Equal(input, test.Name);
            }
        }
    }
}
