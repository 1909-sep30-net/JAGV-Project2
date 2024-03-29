﻿using System.Collections.Generic;

namespace Project2JAGV.Api.Models
{
    public class PizzaModel
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public string Name { get; set; }

        public ICollection<PizzaIngredientModel> PizzaIngredients { get; set; }
    }
}
