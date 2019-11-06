using Project2JAGV.ObjectLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2JAGV.Api.Models
{
    public class IngredientModel
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IngredientTypeModel IngredientType { get; set; }
    }
}
