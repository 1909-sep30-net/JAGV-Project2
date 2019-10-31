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
            get => _id;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Id must not be negative");

                _id = value;
            }
        }
        public int UserId
        {
            get => _userId;
            set
            {
                if (value < 0)
                    throw new ArgumentException("User Id must not be negative");

                _userId = value;
            }
        }
        public string UserName
        {
            get => _userName;
            set
            {
                if (value == "")
                    throw new ArgumentException("User name must not be empty");

                _userName = value;
            }
        }
        public string UserPassword
        {
            get => _userPassword;
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
