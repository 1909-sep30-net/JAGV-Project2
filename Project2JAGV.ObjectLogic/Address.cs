using System;

namespace Project2JAGV.ObjectLogic
{
    public class Address
    {
        private int _id { get; set; }
        private string _street { get; set; }
        private string _city { get; set; }
        private string _state { get; set; }
        private string _zipCode { get; set; }
        public int Id
        {
            get => _id;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Id must not be negative", nameof(value));

                _id = value;
            }
        }
        public string Street
        {
            get
            {

                if (_street == null)
                    throw new ArgumentException("Street is not set", nameof(_street));

                return _street;
            }
            set
            {
                if (value == "")
                    throw new ArgumentException("Street must not be empty", nameof(value));

                _street = value;
            }
        }
        public string City
        {
            get
            {
                if (_city == null)
                    throw new ArgumentException("City is not set", nameof(_city));

                return _city;
            }
            set
            {
                if (value == "")
                    throw new ArgumentException("City must not be empty", nameof(value));

                _city = value;
            }
        }
        public string State
        {
            get
            {

                if (_state == null)
                    throw new ArgumentException("State is not set", nameof(_city));

                return _state;
            }
            set
            {
                if (value == "")
                    throw new ArgumentException("State must not be empty", nameof(value));

                _state = value;
            }
        }
        public string ZipCode
        {
            get
            {

                if (_zipCode == null)
                    throw new ArgumentException("Zip code is not set", nameof(_zipCode));

                return _zipCode;
            }
            set
            {
                if (value == "")
                    throw new ArgumentException("Zip code must not be empty", nameof(value));

                _zipCode = value;
            }
        }
    }
}
