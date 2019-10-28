﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Project2JAGV.DataAccess.Entities
{
    public partial class Orders
    {
        public Orders()
        {
            Pizzas = new HashSet<Pizzas>();
        }
        public int Id { get; set; }
        public int UserId { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Pizzas> Pizzas { get; set; }
    }
}
