using System;

namespace Project2JAGV.ObjectLogic
{
    public class IngredientType
    {
        private int _id;
        private string _name;
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
    }
}
