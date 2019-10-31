using System;

namespace Project2JAGV.ObjectLogic
{
    public class order
    {
        private int _id;
        private int _userId;
        private int _delivererId;
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
        public int UserId
        {
            get => _userId;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("User Id must not be negative");
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
                    throw new ArgumentException("User Id must not be negative");
                }

                _delivererId = value;
            }
        }

        public bool Delivered { get; set; }
        public DateTime Date { get; set; }
    }
}
