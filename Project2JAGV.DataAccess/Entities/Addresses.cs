using System;
using System.Collections.Generic;
using System.Text;

namespace Project2JAGV.DataAccess.Entities
{
    public partial class Addresses
    {
        public Addresses()
        {
            Users = new HashSet<Users>();
        }
        public int Id { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
