using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project2JAGV.DataAccess.Entities
{
    public partial class Ingredients
    {
        public Ingredients()
        {
            PizzaIngredients = new HashSet<PizzaIngredients>();
        }

        [Key]
        public int Id { get; set; }
        [ForeignKey("IngredientType")]
        public int TypeId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual IngredientTypes IngredientType { get; set;  }
        public virtual ICollection<PizzaIngredients> PizzaIngredients { get; set; }
    }
}
