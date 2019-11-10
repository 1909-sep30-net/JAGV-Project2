using System.ComponentModel.DataAnnotations;

namespace Project2JAGV.Api.Models
{
    public class IngredientTypeModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
