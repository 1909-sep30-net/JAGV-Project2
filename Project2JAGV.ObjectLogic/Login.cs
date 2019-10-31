using System;

namespace Project2JAGV.ObjectLogic
{
    public class Login
    {
        private int _id;
        private int _userId;
        private string _userName;
        private string _userPassword;
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
                    throw new ArgumentException("Id must not be negative");

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
                    throw new ArgumentException("User Id must not be negative");

                _userId = value;
            }
        }
        public string UserName
        {
            get
            {

                if (_userName == null)
                    throw new ArgumentNullException("User name is not set");

                return _userName;
            }
            set
            {
                if (value == "")
                    throw new ArgumentException("User name must not be empty");

                _userName = value;
            }
        }
        public string UserPassword
        {
            get
            {

                if (_userPassword == null)
                    throw new ArgumentNullException("User password is not set");

                return _userPassword;
            }
            set
            {
                if (value == "")
                    throw new ArgumentException("User password must not be empty");

                _userPassword = value;
            }
        }
        public bool Admin { get; set; }
    }
}
