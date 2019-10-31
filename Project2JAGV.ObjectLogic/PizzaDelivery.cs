using System;

namespace Project2JAGV.ObjectLogic
{
    public class PizzaDelivery
    {
        private int _id;
        private int _orderId;
        private int _driverd;
        public int Id
        {
            get => _id;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Id must not be negative");
                }

                _id = value;
            }
        }
        public int OrderId
        {
            get => _orderId;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Order Id must not be negative");
                }

                _orderId = value;
            }
        }
        public int DriverId
        {
            get => _driverd;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Driver Id must not be negative");
                }

                _driverd = value;
            }
        }
    }
}
