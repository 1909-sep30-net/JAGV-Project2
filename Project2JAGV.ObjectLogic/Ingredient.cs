using System;

namespace Project2JAGV.ObjectLogic
{
    public class Ingredient
    {
        private int _id;
        private int _typeId;
        private string _name;
        private decimal _price;
        public IngredientType IngredientType { get; set; }
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
        public int TypeId
        {
            get => _typeId;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Type Id must not be negative", nameof(value));

                _typeId = value;
            }
        }
        public string Name
        {
            get
            {

                if (_name == null)
                    throw new ArgumentException("Name is not set", nameof(_name));

                return _name;
            }
            set
            {
                if (value == "")
                    throw new ArgumentException("Name must not be empty", nameof(value));

                _name = value;
            }
        }
        public decimal Price
        {
            get
            {

                if (_price == 0)
                    throw new ArgumentException("Price is not set");

                return _price;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Price must not be negative", nameof(value));

                _price = value;
            }
        }
    }
}
