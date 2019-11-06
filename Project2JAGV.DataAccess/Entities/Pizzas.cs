using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2JAGV.DataAccess.Entities
{
    public partial class Pizzas
    {
        public Pizzas()
        {
            PizzaIngredients = new HashSet<PizzaIngredients>();
        }
        [Key]
        public int Id { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public string Name { get; set; }
        public virtual Orders Order { get; set; }
        public virtual ICollection<PizzaIngredients> PizzaIngredients { get; set; }
    }
}
