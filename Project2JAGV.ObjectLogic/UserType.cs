using System;
using System.Collections.Generic;
using System.Text;

namespace Project2JAGV.ObjectLogic
{
    public class UserType
    {
        private int _id;
        private string _type;
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
        public string Type
        {
            get => _type;
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Type must not be empty");
                }
                _type = value;
            }
        }
    }
}
