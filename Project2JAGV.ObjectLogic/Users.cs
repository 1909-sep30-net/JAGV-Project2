using System;
using System.Collections.Generic;
using System.Text;

namespace Project2JAGV.ObjectLogic
{
    public class Users
    {
        
        private int _id { get; set; }

        private string _firstName { get; set; }


        public int Id
        {
            get => _id;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("User Id can not be les than 0");
                }

                _id = value;
            }
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Usernaem cannot be empty");
                }
            }
        }
    }
}
