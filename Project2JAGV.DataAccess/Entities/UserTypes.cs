using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Project2JAGV.DataAccess.Entities
{
    public class UserTypes
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public ICollection<Logins> Logins { get; set; }
    }
}
