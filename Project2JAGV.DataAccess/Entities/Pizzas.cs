using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project2JAGV.DataAccess.Entities
{
    public partial class Pizzas
    {
        public Pizzas()
        {
            Ingredients = new HashSet<PizzaIngredients>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PizzaIngredients> Ingredients { get; set; }
    }
}
