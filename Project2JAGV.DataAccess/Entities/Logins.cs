using System;
using System.Collections.Generic;
using System.Text;

namespace Project2JAGV.DataAccess.Entities
{
    public partial class Logins
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public bool Admin { get; set; }

        public virtual Users User { get; set; }
    }
}
