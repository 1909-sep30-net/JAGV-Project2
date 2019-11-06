using Project2JAGV.ObjectLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project2JAGV.Api.Models
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string UserPassword { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int UserTypeId { get; set; }

        public UserTypeModel UserType { get; set; }
    }
}
