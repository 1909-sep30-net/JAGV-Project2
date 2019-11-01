using System;

namespace Project2JAGV.ObjectLogic
{
    public class PizzaIngredient
    {
        private int _id;
        private int _pizzaId;
        private int _ingredientId;
        public Ingredient Ingredient { get; set; }
        public int Id
        {
            get => _id;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Id must not be negative", nameof(_id));
                }

                _id = value;
            }
        }
        public int PizzaId
        {
            get => _pizzaId;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Pizza Id must not be negative", nameof(_pizzaId));
                }

                _pizzaId = value;
            }
        }
        public int IngredientId
        {
            get => _ingredientId;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Ingredient Id must not be negative", nameof(_ingredientId));
                }

                _ingredientId = value;
            }
        }
    }
}
