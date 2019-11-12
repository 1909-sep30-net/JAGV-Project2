using System;
using System.Collections.Generic;

namespace Project2JAGV.Api.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int DelivererId { get; set; }

        public bool Delivered { get; set; }

        public ICollection<PizzaModel> Pizzas { get; set; }
    }
}
