using Project2JAGV.ObjectLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2JAGV.Api.Models
{
    public class LoginModel
    {
        public string UserName { get; set; }

        public string UserPassword { get; set; }

        public int UserId { get; set; }

        public int UserTypeId { get; set; }

        public UserTypeModel UserType { get; set; }
    }
}
