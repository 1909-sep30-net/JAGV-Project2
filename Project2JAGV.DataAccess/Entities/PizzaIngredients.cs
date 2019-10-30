using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project2JAGV.DataAccess.Entities
{
    public partial class PizzaIngredients
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Pizza")]
        public int PizzaId { get; set; }

        [ForeignKey("Ingredient")]
        public int IngredientId { get; set; }

        public virtual Pizzas Pizza { get; set; }
        public virtual Ingredients Ingredient { get; set; }
    }
}
