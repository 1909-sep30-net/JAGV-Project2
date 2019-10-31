using System;
using System.Collections.Generic;

namespace Project2JAGV.ObjectLogic
{
    public class Driver
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        public int Id
        {
            get => _id;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Id must not be negative");

                _id = value;
            }
        }
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value == "")
                    throw new ArgumentException("First name must not be empty");

                _firstName = value;
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                if (value == "")
                    throw new ArgumentException("Last name must not be empty");

                _lastName = value;
            }
        }

        public virtual ICollection<PizzaDelivery> PizzaDeliveries { get; set; } = new List<PizzaDelivery>();
    }
}
