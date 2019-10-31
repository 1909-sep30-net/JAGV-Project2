using System;

namespace Project2JAGV.ObjectLogic
{
    public class Order
    {
        private int _id;
        private int _userId;
        public int Id
        {
            get
            {

                if (!(_id >= 0))
                    throw new ArgumentNullException("Id is not set");

                return _id;
            }
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
            get
            {

                if (!(_userId >= 0))
                    throw new ArgumentNullException("User Id is not set");

                return _userId;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("User Id must not be negative");
                }

                _userId = value;
            }
        }
        public DateTime Date { get; set; }
    }
}
