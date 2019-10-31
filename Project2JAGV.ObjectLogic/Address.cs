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
                    throw new ArgumentException("Id must not be negative");

                _id = value;
            }
        }
        public string Street
        {
            get => _street;
            set
            {
                if (value == "")
                    throw new ArgumentException("Street must not be empty");

                _street = value;
            }
        }
        public string City
        {
            get => _city;
            set
            {
                if (value == "")
                    throw new ArgumentException("City must not be empty");

                _city = value;
            }
        }
        public string State
        {
            get => _state;
            set
            {
                if (value == "")
                    throw new ArgumentException("State must not be empty");

                _state = value;
            }
        }
        public string ZipCode
        {
            get => _zipCode;
            set
            {
                if (value == "")
                    throw new ArgumentException("Zip code must not be empty");

                _zipCode = value;
            }
        }
    }
}
