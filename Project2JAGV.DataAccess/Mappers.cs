using Project2JAGV.DataAccess.Interfaces;
using Project2JAGV.ObjectLogic;
using System.Linq;

namespace Project2JAGV.DataAccess
{
    public class Mappers : IMappers
    {
        public Mappers() { }
        public Address MapAddress(Entities.Addresses address)
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
        public Entities.Addresses MapAddress(Address address)
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
        public Ingredient MapIngredient(Entities.Ingredients ingredient)
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
                },
            };
        }
        public Entities.Ingredients MapIngredient(Ingredient ingredient)
        {
            return new Entities.Ingredients
            {
                Id = ingredient.Id,
                TypeId = ingredient.TypeId,
                Name = ingredient.Name,
                Price = ingredient.Price,
                IngredientType = new Entities.IngredientTypes
                {
                    Id = ingredient.IngredientType.Id,
                    Name = ingredient.IngredientType.Name,
                },
            };
        }
        public IngredientType MapIngredientType(Entities.IngredientTypes ingredientType)
        {
            return new IngredientType
            {
                Id = ingredientType.Id,
                Name = ingredientType.Name,
            };
        }
        public Entities.IngredientTypes MapIngredientType(IngredientType ingredientType)
        {
            return new Entities.IngredientTypes
            {
                Id = ingredientType.Id,
                Name = ingredientType.Name,
            };
        }
        
        public Order MapOrder(Entities.Orders order)
        {
            return new Order
            {
                Id = order.Id,
                UserId = order.UserId,
                DelivererId = order.DelivererId,
                Delivered = order.Delivered,
                Date = order.Date,
                Pizzas = order.Pizzas.Select(MapPizza).ToList(),
            };
        }
        public Entities.Orders MapOrder(Order order)
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
        public Pizza MapPizza(Entities.Pizzas pizza)
        {
            return new Pizza
            {
                Id = pizza.Id,
                OrderId = pizza.OrderId,
                Name = pizza.Name,
                PizzaIngredients = pizza.PizzaIngredients.Select(MapPizzaIngredient).ToList(),
            };
        }
        public Entities.Pizzas MapPizza(Pizza pizza)
        {
            return new Entities.Pizzas
            {
                Id = pizza.Id,
                Name = pizza.Name,
                OrderId = pizza.OrderId,
                PizzaIngredients = pizza.PizzaIngredients.Select(MapPizzaIngredient).ToList(),
            };
        }
        public PizzaIngredient MapPizzaIngredient(Entities.PizzaIngredients pizzaIngredient)
        {
            return new PizzaIngredient
            {
                Id = pizzaIngredient.Id,
                PizzaId = pizzaIngredient.PizzaId,
                IngredientId = pizzaIngredient.IngredientId,
                Ingredient = MapIngredient(pizzaIngredient.Ingredient),
            };
        }
        public Entities.PizzaIngredients MapPizzaIngredient(PizzaIngredient pizzaIngredient)
        {
            return new Entities.PizzaIngredients
            {
                Id = pizzaIngredient.Id,
                PizzaId = pizzaIngredient.PizzaId,
                IngredientId = pizzaIngredient.IngredientId,
            };
        }
        public User MapUser(Entities.Users user)
        {
            return new User
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                UserType = MapUserType(user.UserType),
                Address = MapAddress(user.Address),
                Orders = user.Orders.Select(MapOrder).ToList(),
            };
        }
        public Entities.Users MapUser(User user)
        {
            return new Entities.Users
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                UserTypeId = user.UserType.Id,
                AddressId = user.Address.Id,
                // dont think we need these
                //UserType = MapUserType(user.UserType),
                //Address = MapAddress(user.Address),
                Orders = user.Orders.Select(MapOrder).ToList(),
            };
        }
        public UserType MapUserType(Entities.UserTypes userType)
        {
            return new UserType
            {
                Id = userType.Id,
                Name = userType.Name,
            };
        }
        public Entities.UserTypes MapUserType(UserType userType)
        {
            return new Entities.UserTypes
            {
                Id = userType.Id,
                Name = userType.Name,
            };
        }
    }
}
