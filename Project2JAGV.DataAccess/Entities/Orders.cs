using System;
using System.Collections.Generic;
using System.Text;

namespace Project2JAGV.DataAccess.Entities
{
    public partial class Orders
    {
        public Orders()
        {
            Pizzas = new HashSet<Pizzas>();
        }
        public int Id { get; set; }
        public int CostumerId { get; set; }
        public ICollection<Pizzas> Pizzas { get; set; }
    }
}
