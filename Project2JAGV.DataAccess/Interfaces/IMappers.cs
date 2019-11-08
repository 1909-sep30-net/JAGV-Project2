using System;
using System.Collections.Generic;
using System.Text;
using Project2JAGV.ObjectLogic;


namespace Project2JAGV.DataAccess.Interfaces
{
    public interface IMappers
    {
        public Address MapAddress(Entities.Addresses address);

        public Entities.Addresses MapAddress(Address address);

        public Ingredient MapIngredient(Entities.Ingredients ingredient);

        public Entities.Ingredients MapIngredient(Ingredient ingredient);

        public IngredientType MapIngredientType(Entities.IngredientTypes ingredientType);

        public Entities.IngredientTypes MapIngredientType(IngredientType ingredientType);

        public Order MapOrder(Entities.Orders order);

        public Entities.Orders MapOrder(Order order);

        public Pizza MapPizza(Entities.Pizzas pizza);

        public Entities.Pizzas MapPizza(Pizza pizza);

        public PizzaIngredient MapPizzaIngredient(Entities.PizzaIngredients pizzaIngredient);

        public Entities.PizzaIngredients MapPizzaIngredient(PizzaIngredient pizzaIngredient);

        public User MapUser(Entities.Users user);

        public Entities.Users MapUser(User user);

        public UserType MapUserType(Entities.UserTypes userType);

        public Entities.UserTypes MapUserType(UserType userType);
       
    }
}
