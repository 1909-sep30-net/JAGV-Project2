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
        public static Ingredient MapIngredient(Entities.Ingredients ingredient)
        {
            return new Ingredient
            {
                Id = ingredient.Id,
                TypeId = ingredient.TypeId,
                Name = ingredient.Name,
                Price = ingredient.Price,
                IngredientType = new IngredientType
                {
                    Id = ingredient.IngredientType.Id,
                    Name = ingredient.IngredientType.Name,
                }
            };
        }
        public static Entities.Ingredients MapIngredient(Ingredient ingredient)
        {
            return new Entities.Ingredients
            {
                Id = ingredient.Id,
                TypeId = ingredient.TypeId,
                Name = ingredient.Name,
                Price = ingredient.Price,
            };
        }
        public static IngredientType MapIngredientType(Entities.IngredientTypes ingredientType)
        {
            return new IngredientType
            {
                Id = ingredientType.Id,
                Name = ingredientType.Name,
            };
        }
        public static Entities.IngredientTypes MapIngredientType(IngredientType ingredientType)
        {
            return new Entities.IngredientTypes
            {
                Id = ingredientType.Id,
                Name = ingredientType.Name,
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
                UserType = new UserType
                {
                    Id = login.UserType.Id,
                    Name = login.UserType.Name,
                }
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
        public static order MapOrder(Entities.Orders order)
        {
            return new order
            {
                Id = order.Id,
                UserId = order.UserId,
                DelivererId = order.DelivererId,
                Delivered = order.Delivered,
                Date = order.Date,
                Pizzas = order.Pizzas.Select(MapPizza).ToList(),
            };
        }
        public static Entities.Orders MapOrder(order order)
        {
            return new Entities.Orders
            {
                Id = order.Id,
                UserId = order.UserId,
                DelivererId = order.DelivererId,
                Delivered = order.Delivered,
                Date = order.Date,
                Pizzas = order.Pizzas.Select(MapPizza).ToList(),
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
        public static PizzaIngredient MapPizzaIngredient(Entities.PizzaIngredients pizzaIngredient)
        {
            return new PizzaIngredient
            {
                Id = pizzaIngredient.Id,
                PizzaId = pizzaIngredient.PizzaId,
                IngredientId = pizzaIngredient.IngredientId,
                Ingredient = MapIngredient(pizzaIngredient.Ingredient),
            };
        }
        public static Entities.PizzaIngredients MapPizzaIngredient(PizzaIngredient pizzaIngredient)
        {
            return new Entities.PizzaIngredients
            {
                Id = pizzaIngredient.Id,
                PizzaId = pizzaIngredient.PizzaId,
                IngredientId = pizzaIngredient.IngredientId,
                Ingredient = MapIngredient(pizzaIngredient.Ingredient),
            };
        }
        public static User MapUser(Entities.Users user)
        {
            return new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Login = MapLogin(user.Login),
                Address = MapAddress(user.Address),
                Orders = user.Orders.Select(MapOrder).ToList(),
            };
        }
        public static Entities.Users MapUser(User user)
        {
            return new Entities.Users
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Login = MapLogin(user.Login),
                Address = MapAddress(user.Address),
                Orders = user.Orders.Select(MapOrder).ToList(),
            };
        }
        public static UserType MapUserType(Entities.UserTypes userType)
        {
            return new UserType
            {
                Id = userType.Id,
                Name = userType.Name,
            };
        }
        public static Entities.UserTypes MapUserType(UserType userType)
        {
            return new Entities.UserTypes
            {
                Id = userType.Id,
                Name = userType.Name,
            };
        }
    }
}
