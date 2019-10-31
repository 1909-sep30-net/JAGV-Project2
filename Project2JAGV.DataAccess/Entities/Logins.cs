using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project2JAGV.DataAccess.Entities
{
    public partial class Logins
    {
        [Key]
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("UserType")]
        public int UserTypeId { get; set; }
        public Users User { get; set; }
        public UserTypes UserType { get; set; }
    }
}
