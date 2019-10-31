using System;

namespace Project2JAGV.ObjectLogic
{
    public class Ingredient
    {
        private int _id;
        private int _typeId;
        private string _name;
        private decimal _price;
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
        public int TypeId
        {
            get
            {

                if (!(_typeId >= 0))
                    throw new ArgumentNullException("Type Id is not set");

                return _typeId;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Type Id must not be negative");

                _typeId = value;
            }
        }
        public string Name
        {
            get
            {

                if (_name == null)
                    throw new ArgumentNullException("Name is not set");

                return _name;
            }
            set
            {
                if (value == "")
                    throw new ArgumentException("Name must not be empty");

                _name = value;
            }
        }
        public decimal Price
        {
            get
            {

                if (!(_price >= 0))
                    throw new ArgumentNullException("Price is not set");

                return _price;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Prie must not be negative");

                _price = value;
            }
        }
    }
}
