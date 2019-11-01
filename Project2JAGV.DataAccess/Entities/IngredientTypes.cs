using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project2JAGV.DataAccess.Entities
{
    public partial class IngredientTypes
    {
        public IngredientTypes()
        {
            Ingredients = new HashSet<Ingredients>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Ingredients> Ingredients { get; set; }
    }
}
