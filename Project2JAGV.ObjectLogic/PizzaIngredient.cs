using System;

namespace Project2JAGV.ObjectLogic
{
    public class PizzaIngredient
    {
        private int _id;
        private int _pizzaId;
        private int _ingredientId;
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
                {
                    throw new ArgumentException("Id must not be negative");
                }

                _id = value;
            }
        }
        public int PizzaId
        {
            get
            {

                if (!(_pizzaId >= 0))
                    throw new ArgumentNullException("User name is not set");

                return _pizzaId;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Pizza Id must not be negative");
                }

                _pizzaId = value;
            }
        }
        public int IngredientId
        {
            get
            {

                if (!(_ingredientId >= 0))
                    throw new ArgumentNullException("User name is not set");

                return _ingredientId;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Ingredient Id must not be negative");
                }

                _ingredientId = value;
            }
        }
    }
}
