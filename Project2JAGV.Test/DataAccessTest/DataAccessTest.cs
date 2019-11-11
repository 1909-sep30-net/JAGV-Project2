using Xunit;
using Project2JAGV.ObjectLogic;
using Project2JAGV.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Project2JAGV.DataAccess.Interfaces;
using System.Threading.Tasks;
using System;

namespace Project2JAGV.Test.DataAccessTest
{
    public class DataAccessTest
    {
        [Fact]
        public async Task AddAddressAsyncAdds()
        {
            var options = new DbContextOptionsBuilder<Project2JAGVContext>()
                .UseInMemoryDatabase("AddAddressAsyncGets")
                .Options;

            Address address = new Address
            {
                Id = 1,
                Street = "Street",
                City = "City",
                State = "State",
                ZipCode = "ZipCode",
            };

            using var actContext = new Project2JAGVContext(options);
            var repo = new DataAccess.DataAccess(actContext, new MapperStub());

            // act
            await repo.AddAddressAsync(address);
            await repo.SaveAsync();

            using var arrangeContext = new Project2JAGVContext(options);
            var result = arrangeContext.Addresses;

            // assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetAddressesAsyncGets()
        {
            var options = new DbContextOptionsBuilder<Project2JAGVContext>()
                .UseInMemoryDatabase("GetAddressesAsyncGets")
                .Options;
            using var arrangeContext = new Project2JAGVContext(options);

            Addresses addresses = new Addresses
            {
                Id = 1,
                Street = "Street",
                City = "City",
                State = "State",
                ZipCode = "ZipCode",
            };

            Address address = new Address
            {
                Id = 1,
                Street = "Street",
                City = "City",
                State = "State",
                ZipCode = "ZipCode",
            };

            arrangeContext.Addresses.Add(addresses);
            arrangeContext.SaveChanges();

            using var actContext = new Project2JAGVContext(options);
            var repo = new DataAccess.DataAccess(actContext, new MapperStub());

            var result = await repo.GetAddressesAsync(id: addresses.Id, address: address);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task AddIngredientAsyncAdds()
        {
            var options = new DbContextOptionsBuilder<Project2JAGVContext>()
                .UseInMemoryDatabase("AddIngredientAsyncAdds")
                .Options;

            Ingredient ingredient = new Ingredient
            {
                Id = 1,
                TypeId = 1,
                Name = "name",
                Price = 1,
                IngredientType = new IngredientType
                {
                    Id = 1,
                    Name = "name",
                }
            };

            using var actContext = new Project2JAGVContext(options);
            var repo = new DataAccess.DataAccess(actContext, new MapperStub());

            await repo.AddIngredientAsync(ingredient);
            await repo.SaveAsync();

            using var arrangeContext = new Project2JAGVContext(options);
            var result = arrangeContext.Ingredients;

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetIngredientsAsyncGets()
        {
            var options = new DbContextOptionsBuilder<Project2JAGVContext>()
                .UseInMemoryDatabase("GetIngredientsAsyncGets")
                .Options;

            Ingredients ingredients = new Ingredients
            {
                Id = 1,
                Name = "name",
                Price = 1,
            };

            using var arrangeContext = new Project2JAGVContext(options);

            arrangeContext.Add(ingredients);
            arrangeContext.SaveChanges();

            using var actContext = new Project2JAGVContext(options);
            var repo = new DataAccess.DataAccess(actContext, new MapperStub());

            var result = await repo.GetIngredientsAsync();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task AddIngredientTypeAsyncAdds()
        {
            var options = new DbContextOptionsBuilder<Project2JAGVContext>()
                .UseInMemoryDatabase("AddIngredientTypeAsyncAdds")
                .Options;

            IngredientType ingredientType = new IngredientType
            {
                Id = 1,
                Name = "name",
            };

            using var actContext = new Project2JAGVContext(options);
            var repo = new DataAccess.DataAccess(actContext, new MapperStub());

            await repo.AddIngredientTypeAsync(ingredientType);
            await repo.SaveAsync();

            using var arrangeContext = new Project2JAGVContext(options);
            var result = arrangeContext.IngredientTypes;

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetIngredientTypesAsyncGets()
        {
            var options = new DbContextOptionsBuilder<Project2JAGVContext>()
                .UseInMemoryDatabase("GetIngredientsAsyncGets")
                .Options;

            IngredientTypes ingredientTypes = new IngredientTypes
            {
                Id = 1,
                Name = "name",
            };

            using var arrangeContext = new Project2JAGVContext(options);

            arrangeContext.Add(ingredientTypes);
            arrangeContext.SaveChanges();

            using var actContext = new Project2JAGVContext(options);
            var repo = new DataAccess.DataAccess(actContext, new MapperStub());

            var result = await repo.GetIngredientTypesAsync();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task AddOrderAsyncAdds()
        {
            var options = new DbContextOptionsBuilder<Project2JAGVContext>()
                .UseInMemoryDatabase("AddOrderAsyncAdds")
                .Options;

            Order order = new Order
            {
                Id = 1,
                UserId = 1,
                DelivererId = 1,
                Delivered = false,
                Date = DateTime.Now,
            };

            using var actContext = new Project2JAGVContext(options);
            var repo = new DataAccess.DataAccess(actContext, new MapperStub());

            await repo.AddOrderAsync(order);
            await repo.SaveAsync();

            using var arrangeContext = new Project2JAGVContext(options);
            var result = arrangeContext.Orders;

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetOrdersAsynGetsc()
        {
            var options = new DbContextOptionsBuilder<Project2JAGVContext>()
                .UseInMemoryDatabase("GetOrdersAsynGetsc")
                .Options;

            Orders orders = new Orders
            {
                Id = 1,
                UserId = 1,
                DelivererId = 1,
                Delivered = false,
                Date = DateTime.Now,
            };

            using var arrangeContext = new Project2JAGVContext(options);

            arrangeContext.Add(orders);
            arrangeContext.SaveChanges();

            using var actContext = new Project2JAGVContext(options);
            var repo = new DataAccess.DataAccess(actContext, new MapperStub());

            var result = await repo.GetOrdersAsync(id: orders.Id, userId: orders.UserId,
                delivererId: orders.DelivererId, delivered: orders.Delivered, date: orders.Date);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task AddPizzaAsyncAdds()
        {
            var options = new DbContextOptionsBuilder<Project2JAGVContext>()
                .UseInMemoryDatabase("AddOrderAsyncAdds")
                .Options;

            Pizza pizza = new Pizza
            {
                Id = 1,
                OrderId = 1,
                Name = "name",
            };

            using var actContext = new Project2JAGVContext(options);
            var repo = new DataAccess.DataAccess(actContext, new MapperStub());

            await repo.AddPizzaAsync(pizza);
            await repo.SaveAsync();

            using var arrangeContext = new Project2JAGVContext(options);
            var result = arrangeContext.Pizzas;

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetPizzasAsyncGets()
        {
            var options = new DbContextOptionsBuilder<Project2JAGVContext>()
                .UseInMemoryDatabase("GetOrdersAsynGetsc")
                .Options;

            Pizzas pizzas = new Pizzas
            {
                Id = 1,
                OrderId = 1,
                Name = "name",
            };

            using var arrangeContext = new Project2JAGVContext(options);

            arrangeContext.Add(pizzas);
            arrangeContext.SaveChanges();

            using var actContext = new Project2JAGVContext(options);
            var repo = new DataAccess.DataAccess(actContext, new MapperStub());

            var result = await repo.GetPizzasAsync(id: pizzas.Id, orderId: pizzas.OrderId, name: pizzas.Name);

            Assert.NotNull(result);
        }

        [Fact]
        public void GetUsersAsyncGetsAllUsers()
        {
            var options = new DbContextOptionsBuilder<Project2JAGVContext>()
                .UseInMemoryDatabase("GetUsersAsyncGetsAllUsers")
                .Options;
            using var arrangeContext = new Project2JAGVContext(options);

            int id = 1;
            string name = "name";
            string password = "password";
            int addressId = 1;
            int userTypeId = 1;

            arrangeContext.Users.Add(new Users { Id = id, Name = name, Password = password, UserTypeId = userTypeId, AddressId = addressId, });
            arrangeContext.SaveChanges();

            using var actContext = new Project2JAGVContext(options);
            var repo = new DataAccess.DataAccess(actContext, new MapperStub());

            // act
            var result = repo.GetUsersAsync(id: id, name: name, password: password);

            // assert
            Assert.NotNull(result);
        }

        public class MapperStub : IMappers
        {
            public Address MapAddress(Addresses address)
            {
                return new Address();
            }
            public Addresses MapAddress(Address address)
            {
                return new Addresses();
            }
            public Ingredient MapIngredient(Ingredients ingredient)
            {
                return new Ingredient();
            }
            public Ingredients MapIngredient(Ingredient ingredient)
            {
                return new Ingredients();
            }
            public IngredientType MapIngredientType(IngredientTypes ingredientType)
            {
                return new IngredientType();
            }

            public IngredientTypes MapIngredientType(IngredientType ingredientType)
            {
                return new IngredientTypes();
            }
            public Order MapOrder(Orders order)
            {
                return new Order();
            }
            public Orders MapOrder(Order order)
            {
                return new Orders();
            }
            public Pizza MapPizza(Pizzas pizza)
            {
                return new Pizza();
            }
            public Pizzas MapPizza(Pizza pizza)
            {
                return new Pizzas();
            }

            public PizzaIngredient MapPizzaIngredient(PizzaIngredients pizzaIngredient)
            {
                return new PizzaIngredient();
            }
            public PizzaIngredients MapPizzaIngredient(PizzaIngredient pizzaIngredient)
            {
                return new PizzaIngredients();
            }
            public User MapUser(Users user)
            {
                return new User();
            }
            public Users MapUser(User user)
            {
                return new Users();
            }
            public UserType MapUserType(UserTypes userType)
            {
                return new UserType();
            }
            public UserTypes MapUserType(UserType userType)
            {
                return new UserTypes();
            }
        }

    }
}
