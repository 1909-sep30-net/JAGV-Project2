using System;
using System.Collections.Generic;
using System.Text;

namespace Project2JAGV.DataAccess.Entities
{
    public partial class PizzaIngredients
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int IngredientId { get; set; }

        public virtual Pizzas Pizza { get; set; }
        public virtual Ingredients Ingredient { get; set; }
    }
}
