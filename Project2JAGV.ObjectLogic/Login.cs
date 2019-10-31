using System;

namespace Project2JAGV.ObjectLogic
{
    public class Login
    {
        private string _userName;
        private string _userPassword;
        private int _userId;
        private int _userTypeId;
        public string UserName
        {
            get
            {

                if (_userName == null)
                    throw new ArgumentNullException("Id is not set");

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
                    throw new ArgumentNullException("User Id is not set");

                return _userPassword;
            }
            set
            {
                if (value == "")
                    throw new ArgumentException("User password must not be empty");

                _userPassword = value;
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
        public int UserTypeId
        {
            get => _userTypeId;
            set
            {
                if (value < 0)
                    throw new ArgumentException("User Type Id must not be negative");

                _userTypeId = value;
            }
        }
    }
}
