using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project2JAGV.DataAccess.Entities
{
    public partial class Addresses
    {
        public Addresses()
        {
            Users = new HashSet<Users>();
        }
        [Key]
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
