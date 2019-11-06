using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Project2JAGV.DataAccess.Entities
{
    public class UserTypes
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}
