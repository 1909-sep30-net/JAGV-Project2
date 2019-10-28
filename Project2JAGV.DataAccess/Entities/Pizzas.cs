using System;
using System.Collections.Generic;
using System.Text;

namespace Project2JAGV.DataAccess.Entities
{
    public partial class Pizzas
    {
        public Pizzas()
        {
            Ingredients = new HashSet<PizzaIngredients>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int CrustType { get; set; }
        public int SauceType { get; set; }

        public virtual ICollection<PizzaIngredients> Ingredients { get; set; }
    }
}
