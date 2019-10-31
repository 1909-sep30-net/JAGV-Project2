using Project2JAGV.ObjectLogic;
using System.Linq;

namespace Project2JAGV.DataAccess
{
    public class Mappers
    {
        public static Address MapAddress(Entities.Addresses address)
        {
            return new Address
            {
                Id = address.Id,
                Street = address.Street,
                City = address.City,
                State = address.State,
                ZipCode = address.ZipCode,
            };
        }
        public static Entities.Addresses MapAddress(Address address)
        {
            return new Entities.Addresses
            {
                Id = address.Id,
                Street = address.Street,
                City = address.City,
                State = address.State,
                ZipCode = address.ZipCode,
            };
        }
        public static Ingredient MapIngredient(Entities.Ingredients ingresient)
        {
            return new Ingredient
            {
                Id = ingresient.Id,
                TypeId = ingresient.TypeId,
                Name = ingresient.Name,
                Price = ingresient.Price,
            };
        }
        public static Entities.Ingredients MapIngredient(Ingredient ingresient)
        {
            return new Entities.Ingredients
            {
                Id = ingresient.Id,
                TypeId = ingresient.TypeId,
                Name = ingresient.Name,
                Price = ingresient.Price,
            };
        }
        public static IngredientType MapIngredientType(Entities.IngredientTypes ingredientType)
        {
            return new IngredientType
            {
                Id = ingredientType.Id,
                Type = ingredientType.Type,
            };
        }
        public static Entities.IngredientTypes MapIngredientType(IngredientType ingredientType)
        {
            return new Entities.IngredientTypes
            {
                Id = ingredientType.Id,
                Type = ingredientType.Type,
            };
        }
        public static Login MapLogin(Entities.Logins login)
        {
            return new Login
            {
                UserName = login.UserName,
                UserPassword = login.UserPassword,
                UserId = login.UserId,
                UserTypeId = login.UserTypeId,
            };
        }
        public static Entities.Logins MapLogin(Login login)
        {
            return new Entities.Logins
            {
                UserName = login.UserName,
                UserPassword = login.UserPassword,
                UserId = login.UserId,
                UserTypeId = login.UserTypeId,
            };
        }
        public static Order MapOrder(Entities.Orders order)
        {
            return new Order
            {
                Id = order.Id,
                UserId = order.UserId,
                DelivererId = order.DelivererId,
                Delivered = order.Delivered,
                Date = order.Date,
            };
        }
        public static Entities.Orders MapOrder(Order order)
        {
            return new Entities.Orders
            {
                Id = order.Id,
                UserId = order.UserId,
                DelivererId = order.DelivererId,
                Delivered = order.Delivered,
                Date = order.Date,
            };
        }
        public static Pizza MapPizza(Entities.Pizzas pizza)
        {
            return new Pizza
            {
                Id = pizza.Id,
                Name = pizza.Name,
                PizzaIngredients = pizza.PizzaIngredients.Select(MapPizzaIngredient).ToList(),
            };
        }
        public static Entities.Pizzas MapPizza(Pizza pizza)
        {
            return new Entities.Pizzas
            {
                Id = pizza.Id,
                Name = pizza.Name,
                PizzaIngredients = pizza.PizzaIngredients.Select(MapPizzaIngredient).ToList(),
            };
        }
        public static PizzaIngredient MapPizzaIngredient(Entities.PizzaIngredients pizzaIngredients)
        {
            return new PizzaIngredient
            {
                Id = pizzaIngredients.Id,
                PizzaId = pizzaIngredients.PizzaId,
                IngredientId = pizzaIngredients.IngredientId,
            };
        }
        public static Entities.PizzaIngredients MapPizzaIngredient(PizzaIngredient pizzaIngredients)
        {
            return new Entities.PizzaIngredients
            {
                Id = pizzaIngredients.Id,
                PizzaId = pizzaIngredients.PizzaId,
                IngredientId = pizzaIngredients.IngredientId,
            };
        }
        public static User MapUser(Entities.Users user)
        {
            return new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
        }
        public static Entities.Users MapUser(User user)
        {
            return new Entities.Users
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
        }
        public static UserType MapUserType(Entities.UserTypes userType)
        {
            return new UserType
            {
                Id = userType.Id,
                Type = userType.Type,
            };
        }
        public static Entities.UserTypes MapUserType(UserType userType)
        {
            return new Entities.UserTypes
            {
                Id = userType.Id,
                Type = userType.Type,
            };
        }
    }
}
