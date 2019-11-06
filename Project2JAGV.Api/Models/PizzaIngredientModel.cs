using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2JAGV.Api.Models
{
    public class PizzaIngredientModel
    {
        public int Id { get; set; }

        public int PizzaId { get; set; }

        public int IngredientId { get; set; }
    }
}
