using System;
using System.Collections.Generic;
using System.Text;

namespace Project2JAGV.DataAccess.Entities
{
    public partial class PizzaDelivery
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public int OrderId { get; set; }

        public virtual Drivers Driver { get; set; }
        public virtual Orders Order { get; set; }
    }
}
