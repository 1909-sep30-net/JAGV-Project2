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
        public string Name { get; set; }
        public string Password { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        [ForeignKey("UserType")]
        public int UserTypesId { get; set; }
        public virtual Addresses Address { get; set; }
        public virtual UserTypes UserType { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
