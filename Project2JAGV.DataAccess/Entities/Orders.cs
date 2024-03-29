﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2JAGV.DataAccess.Entities
{
    public partial class Orders
    {
        public Orders()
        {
            Pizzas = new HashSet<Pizzas>();
        }
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("Deliverer")]
        public int DelivererId { get; set; }
        public bool Delivered { get; set; }
        public DateTime Date { get; set; }
        public virtual Users User { get; set; }
        public virtual Users Deliverer { get; set; }
        public virtual ICollection<Pizzas> Pizzas { get; set; }
    }
}
