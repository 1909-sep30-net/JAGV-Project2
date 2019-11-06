using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2JAGV.Api.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int DelivererId { get; set; }

        public bool Delivered { get; set; }

        public DateTime Date { get; set; }
    }
}
