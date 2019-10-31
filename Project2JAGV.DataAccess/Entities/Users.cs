using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project2JAGV.DataAccess.Entities
{
    public partial class Users
    {
        public Users()
        {
            Orders = new HashSet<Orders>();
        }
        [Key]
        public int Id { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual Logins Login { get; set; }
        public virtual Addresses Address { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
