
using System.ComponentModel.DataAnnotations;


namespace Project2JAGV.Api.Models
{
    public class IngredientModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int TypeId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IngredientTypeModel IngredientType { get; set; }
    }
}
