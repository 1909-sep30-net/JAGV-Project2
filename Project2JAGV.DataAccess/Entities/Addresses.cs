using System;
using System.Collections.Generic;
using System.Text;

namespace Project2JAGV.DataAccess.Entities
{
    public partial class Addresses
    {
        public Addresses()
        {
            Customers = new HashSet<Customers>();
        }
        public int Id { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public ICollection<Customers> Customers { get; set; }
    }
}
