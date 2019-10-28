using System;
using System.Collections.Generic;
using System.Text;

namespace Project2JAGV.DataAccess.Entities
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual Users user { get; set; }
        public virtual Addresses Address { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }

    }
}
