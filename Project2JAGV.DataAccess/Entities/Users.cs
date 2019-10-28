using System;
using System.Collections.Generic;
using System.Text;

namespace Project2JAGV.DataAccess.Entities
{
    public partial class Users
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public virtual Customers Customer { get; set; }
    }
}
