using System;
using System.Collections.Generic;

namespace Project2JAGV.ObjectLogic
{
    public class User
    {
        private int _id;
        private string _name;
        private string _password;
        public UserType UserType { get; set; }
        public Address Address { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public int Id
        {
            get => _id;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Id must not be negative", nameof(value));
                }

                _id = value;
            }
        }
        public string Name
        {
            get
            {
                if (_name == null)
                    throw new ArgumentException("First name is not set", nameof(_name));

                return _name;
            }
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("First name must not be empty", nameof(value));
                }

                _name = value;
            }
        }
        public string Password
        {
            get
            {
                if (_password == null)
                    throw new ArgumentException("Last name is not set", nameof(_password));

                return _password;
            }
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Last name must not be empty", nameof(value));
                }

                _password = value;
            }
        }
    }
}
