using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project2JAGV.DataAccess.Entities
{
    public partial class Logins
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public bool Admin { get; set; }

        public virtual Users User { get; set; }
    }
}
