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

        public string City
        {
            get
            {

                if (_city == null)
                    throw new ArgumentNullException("City is not set");

                return _city;
            }
            set
            {
                if (value == "")
                    throw new ArgumentException("City must not be empty");

                _city= value;
            }
        }
        public string Street
        {
            get
            {

                if (_street == null)
                    throw new ArgumentNullException("Street is not set");

                return _street;
            }
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
            get
            {

                if (_state == null)
                    throw new ArgumentNullException("State is not set");

                return _state;
            }
            set
            {
                if (value == "")
                    throw new ArgumentException("State must not be empty");

                _state = value;
            }
        }
        public string ZipCode
        {
            get
            {

                if (_zipCode == null)
                    throw new ArgumentNullException("Zip code is not set");

                return _zipCode;
            }
            set
            {
                if (value == "")
                    throw new ArgumentException("Zip code must not be empty");

                _zipCode = value;
            }
        }
    }
}
