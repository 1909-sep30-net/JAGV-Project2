using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2JAGV.Api.Models
{
    public class PizzaModel
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public string Name { get; set; }

        public ICollection<PizzaIngredientModel> pi { get; set; }
    }
}
