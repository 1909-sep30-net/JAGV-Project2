using System;
using System.Collections.Generic;
using System.Text;

namespace Project2JAGV.DataAccess.Entities
{
    public partial class Drivers
    {
        public Drivers()
        {
            PizzaDeliveries = new HashSet<PizzaDelivery>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<PizzaDelivery> PizzaDeliveries { get; set; }
    }
}
