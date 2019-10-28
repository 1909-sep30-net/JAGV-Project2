using System;
using System.Collections.Generic;
using System.Text;

namespace Project2JAGV.ObjectLogic
{
    public class Users
    {
        private int _id { get; set; }
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
    }
}
