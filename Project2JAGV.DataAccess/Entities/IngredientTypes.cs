using System;
using System.Collections.Generic;
using System.Text;

namespace Project2JAGV.DataAccess.Entities
{
    public partial class IngredientTypes
    {
        public IngredientTypes()
        {
            Ingredients = new HashSet<Ingredients>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Ingredients> Ingredients { get; set; }
    }
}
