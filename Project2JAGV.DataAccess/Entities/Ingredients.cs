using System;
using System.Collections.Generic;
using System.Text;

namespace Project2JAGV.DataAccess.Entities
{
    public partial class Ingredients
    {
        public Ingredients()
        {
            PizzaIngredients = new HashSet<PizzaIngredients>();
        }

        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual IngredientTypes IngredientType { get; set;  }
        public virtual ICollection<PizzaIngredients> PizzaIngredients { get; set; }
    }
}
