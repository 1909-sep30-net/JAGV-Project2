using System;

namespace Project2JAGV.ObjectLogic
{
    public class Login
    {
        private string _userName;
        private string _userPassword;
        private int _userId;
        private int _userTypeId;
        public UserType UserType { get; set; }
        public string UserName
        {
            get
            {
                if (_userName == null)
                    throw new ArgumentException("Id is not set", nameof(_userName));

                return _userName;
            }
            set
            {
                if (value == "")
                    throw new ArgumentException("User name must not be empty", nameof(value));

                _userName = value;
            }
        }
        public string UserPassword
        {
            get
            {
                if (_userPassword == null)
                    throw new ArgumentException("User Id is not set", nameof(_userPassword));

                return _userPassword;
            }
            set
            {
                if (value == "")
                    throw new ArgumentException("User password must not be empty", nameof(value));

                _userPassword = value;
            }
        }
        public int UserId
        {
            get => _userId;
            set
            {
                if (value < 0)
                    throw new ArgumentException("User Id must not be negative", nameof(value));

                _userId = value;
            }
        }
        public int UserTypeId
        {
            get => _userTypeId;
            set
            {
                if (value < 0)
                    throw new ArgumentException("User Type Id must not be negative", nameof(value));

                _userTypeId = value;
            }
        }
    }
}
