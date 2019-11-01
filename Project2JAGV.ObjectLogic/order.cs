using System;
using System.Collections.Generic;
using System.Text;

namespace Project2JAGV.ObjectLogic
{
    public class Order
    {
        private int _id;
        private int _userId;
        private int _delivererId;
        public bool Delivered { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Pizza> Pizzas { get; set; } = new List<Pizza>();
        public int Id
        {
            get => _id;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Id must not be negative", nameof(_id));
                }

                _id = value;
            }
        }
        public int UserId
        {
            get => _userId;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("User Id must not be negative", nameof(_userId));
                }

                _userId = value;
            }
        }
        public int DelivererId
        {
            get => _delivererId;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("User Id must not be negative", nameof(_delivererId));
                }

                _delivererId = value;
            }
        }
    }
}
