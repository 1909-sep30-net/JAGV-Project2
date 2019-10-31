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
            get => _id;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Id must not be negative");

                _id = value;
            }
        }
        public int TypeId
        {
            get => _typeId;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Type Id must not be negative");

                _typeId = value;
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                if (value == "")
                    throw new ArgumentException("Name must not be empty");

                _name = value;
            }
        }
        public decimal Price
        {
            get => _price;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Prie must not be negative");

                _price = value;
            }
        }
    }
}
