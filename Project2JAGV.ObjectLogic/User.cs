using System;
using System.Collections.Generic;

namespace Project2JAGV.ObjectLogic
{
    public class User
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        public Login Login { get; set; }
        public Address Address { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
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
        public string FirstName
        {
            get
            {
                if (_firstName == null)
                    throw new ArgumentNullException("First name is not set", nameof(_firstName));

                return _firstName;
            }
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("First name must not be empty", nameof(_firstName));
                }

                _firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                if (_lastName == null)
                    throw new ArgumentNullException("Last name is not set", nameof(_lastName));

                return _lastName;
            }
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Last name must not be empty", nameof(_lastName));
                }

                _lastName = value;
            }
        }
    }
}
