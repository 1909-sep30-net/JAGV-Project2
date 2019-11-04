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
                    throw new ArgumentException("Id must not be negative", nameof(_id));

                _id = value;
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
                    throw new ArgumentException("Name must not be empty", nameof(_name));

                _name = value;
            }
        }
    }
}
