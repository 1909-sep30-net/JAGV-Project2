using System;

namespace Project2JAGV.ObjectLogic
{
    public class User
    {
        private int _id;
        private string _firstName;
        private string _lastName;
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
        public string FirstName
        {
            get
            {

                if (_firstName == null)
                    throw new ArgumentNullException("First name is not set");

                return _firstName;
            }
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("First name must not be empty");
                }

                _firstName = value;
            }
        }
        public string LastName
        {
            get
            {

                if (_lastName == null)
                    throw new ArgumentNullException("Last name is not set");

                return _lastName;
            }
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Last name must not be empty");
                }

                _lastName = value;
            }
        }
    }
}
