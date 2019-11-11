using Xunit;
using Project2JAGV.ObjectLogic;
using Project2JAGV.DataAccess;
using Project2JAGV.DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace Project2JAGV.Test.DataAccessTest
{
    public class MapperTest
    {
        private readonly Mappers mapper = new Mappers();

        [Fact]
        public void AddressToAddressesTest()
        {
            Address address = new Address
            {
                Id = 1,
                Street = "Street",
                City = "City",
                State = "State",
                ZipCode = "ZipCode",
            };

            Addresses addresses = mapper.MapAddress(address);

            Assert.Equal(address.Id, addresses.Id);
            Assert.Equal(address.Street, addresses.Street);
            Assert.Equal(address.City, addresses.City);
            Assert.Equal(address.State, addresses.State);
            Assert.Equal(address.ZipCode, addresses.ZipCode);
        }

        [Fact]
        public void AddressesToAddressTest()
        {
            Addresses addresses = new Addresses
            {
                Id = 1,
                Street = "Street",
                City = "City",
                State = "State",
                ZipCode = "ZipCode",
            };

            Address address = mapper.MapAddress(addresses);

            Assert.Equal(addresses.Id, address.Id);
            Assert.Equal(addresses.Street, address.Street);
            Assert.Equal(addresses.City, address.City);
            Assert.Equal(addresses.State, address.State);
            Assert.Equal(addresses.ZipCode, address.ZipCode);
        }

        [Fact]
        public void IngredientToIngredients()
        {
            Ingredient ingredient = new Ingredient
            {
                Id = 1,
                Name = "Name",
                Price = 1,
                TypeId = 1,
                IngredientType = new IngredientType
                {
                    Id = 1,
                    Name = "Name",
                }
            };

            Ingredients ingredients = mapper.MapIngredient(ingredient);

            Assert.Equal(ingredient.Id, ingredients.Id);
            Assert.Equal(ingredient.Name, ingredients.Name);
            Assert.Equal(ingredient.Price, ingredients.Price);
            Assert.Equal(ingredient.TypeId, ingredients.TypeId);
            Assert.Equal(ingredient.IngredientType.Id, ingredients.IngredientType.Id);
            Assert.Equal(ingredient.IngredientType.Name, ingredients.IngredientType.Name);
        }

        [Fact]
        public void IngredientsToingredientTest()
        {
            Ingredients ingredients = new Ingredients
            {
                Id = 1,
                Name = "Name",
                Price = 1,
                TypeId = 1,
                IngredientType = new IngredientTypes
                {
                    Id = 1,
                    Name = "Name",
                }
            };

            Ingredient ingredient = mapper.MapIngredient(ingredients);

            Assert.Equal(ingredients.Id, ingredient.Id);
            Assert.Equal(ingredients.Name, ingredient.Name);
            Assert.Equal(ingredients.Price, ingredient.Price);
            Assert.Equal(ingredients.TypeId, ingredient.TypeId);
            Assert.Equal(ingredients.IngredientType.Id, ingredient.IngredientType.Id);
            Assert.Equal(ingredients.IngredientType.Name, ingredient.IngredientType.Name);
        }

        [Fact]
        public void IngredientTypeToIngredientTypesTest()
        {
            IngredientType ingredientType = new IngredientType
            {
                Id = 1,
                Name = "Name",
            };

            IngredientTypes ingredientTypes = mapper.MapIngredientType(ingredientType);

            Assert.Equal(ingredientType.Id, ingredientTypes.Id);
            Assert.Equal(ingredientType.Name, ingredientTypes.Name);
        }

        [Fact]
        public void IngredientTypesToIngredientTpye()
        {
            IngredientType ingredientType = new IngredientType
            {
                Id = 1,
                Name = "Name",
            };

            IngredientTypes ingredientTypes = mapper.MapIngredientType(ingredientType);

            Assert.Equal(ingredientType.Id, ingredientTypes.Id);
            Assert.Equal(ingredientType.Name, ingredientTypes.Name);
        }

        [Fact]
        public void OrderToOrdersTest()
        {
            DateTime date = new DateTime();

            Order order = new Order
            {
                Id = 1,
                UserId = 1,
                DelivererId = 1,
                Delivered = false,
                Date = date,
                Pizzas = new List<Pizza>()
                {
                    new Pizza
                    {
                        Id = 1,
                        OrderId = 1,
                        Name = "Name",
                        PizzaIngredients = new List<PizzaIngredient>
                        {
                            new PizzaIngredient
                            {
                                Id = 1,
                                PizzaId = 1,
                                IngredientId = 1,
                                Ingredient = new Ingredient
                                {
                                    Id = 1,
                                    TypeId = 1,
                                    Name = "Name",
                                    Price = 1,
                                    IngredientType = new IngredientType
                                    {
                                        Id = 1,
                                        Name = "Name",
                                    }

                                }
                            }
                        }
                    }
                }
            };

            Orders orders = mapper.MapOrder(order);

            Assert.Equal(order.Id, orders.Id);
            Assert.Equal(order.UserId, orders.UserId);
            Assert.Equal(order.DelivererId, orders.DelivererId);
            Assert.Equal(order.Delivered, orders.Delivered);
            Assert.Equal(order.Date, orders.Date);
        }

        [Fact]
        public void OrdersToOrderTest()
        {
            DateTime date = new DateTime();

            Orders orders = new Orders
            {
                Id = 1,
                UserId = 1,
                DelivererId = 1,
                Delivered = false,
                Date = date,
                Pizzas = new List<Pizzas>()
                {
                    new Pizzas
                    {
                        Id = 1,
                        OrderId = 1,
                        Name = "Name",
                        PizzaIngredients = new List<PizzaIngredients>
                        {
                            new PizzaIngredients
                            {
                                Id = 1,
                                PizzaId = 1,
                                IngredientId = 1,
                                Ingredient = new Ingredients
                                {
                                    Id = 1,
                                    TypeId = 1,
                                    Name = "Name",
                                    Price = 1,
                                    IngredientType = new IngredientTypes
                                    {
                                        Id = 1,
                                        Name = "Name",
                                    }

                                }
                            }
                        }
                    }
                }
            };

            Order order = mapper.MapOrder(orders);

            Assert.Equal(orders.Id, order.Id);
            Assert.Equal(orders.UserId, order.UserId);
            Assert.Equal(orders.DelivererId, order.DelivererId);
            Assert.Equal(orders.Delivered, order.Delivered);
            Assert.Equal(orders.Date, order.Date);
        }

        [Fact]
        public void PizzasToPizzaTest()
        {
            Pizzas pizzas = new Pizzas
            {
                Id = 1,
                OrderId = 1,
                Name = "Name",
                PizzaIngredients = new List<PizzaIngredients>
                {
                    new PizzaIngredients
                    {
                        Id = 1,
                        IngredientId = 1,
                        Ingredient = new Ingredients
                        {
                            Id = 1,
                            Name = "Name",
                            Price = 1,
                            IngredientType = new IngredientTypes
                            {
                                Id = 1,
                                Name = "Name",
                            },
                        },
                    },
                }
            };

            Pizza pizza = mapper.MapPizza(pizzas);

            Assert.Equal(pizzas.Id, pizza.Id);
            Assert.Equal(pizzas.OrderId, pizza.OrderId);
            Assert.Equal(pizzas.Name, pizza.Name);
        }

        [Fact]
        public void PizzaToPizzasTest()
        {
            Pizza pizza = new Pizza
            {
                Id = 1,
                OrderId = 1,
                Name = "Name",
                PizzaIngredients = new List<PizzaIngredient>
                {
                    new PizzaIngredient
                    {
                        Id = 1,
                        IngredientId = 1,
                        Ingredient = new Ingredient
                        {
                            Id = 1,
                            Name = "Name",
                            Price = 1,
                            IngredientType = new IngredientType
                            {
                                Id = 1,
                                Name = "Name",
                            }
                        },
                    },
                }
            };

            Pizzas pizzas = mapper.MapPizza(pizza);

            Assert.Equal(pizza.Id, pizzas.Id);
            Assert.Equal(pizza.OrderId, pizzas.OrderId);
            Assert.Equal(pizza.Name, pizzas.Name);
        }

        [Fact]
        public void PizzaIngredientsToPizzaIngredientTest()
        {
            PizzaIngredients pizzaIngredients = new PizzaIngredients
            {
                Id = 1,
                PizzaId = 1,
                IngredientId = 1,
                Ingredient = new Ingredients
                {
                    Id = 1,
                    Name = "Name",
                    Price = 1,
                    IngredientType = new IngredientTypes
                    {
                        Id = 1,
                        Name = "Name",
                    }
                }
            };

            PizzaIngredient pizzaIngredient = mapper.MapPizzaIngredient(pizzaIngredients);

            Assert.Equal(pizzaIngredients.Id, pizzaIngredient.Id);
            Assert.Equal(pizzaIngredients.PizzaId, pizzaIngredient.PizzaId);
            Assert.Equal(pizzaIngredients.IngredientId, pizzaIngredient.IngredientId);
        }


        [Fact]
        public void PizzaIngredientToPizzaIngredientsTest()
        {
            PizzaIngredient pizzaIngredient = new PizzaIngredient
            {
                Id = 1,
                PizzaId = 1,
                IngredientId = 1,
            };

            PizzaIngredients pizzaIngredients = mapper.MapPizzaIngredient(pizzaIngredient);

            Assert.Equal(pizzaIngredient.Id, pizzaIngredients.Id);
            Assert.Equal(pizzaIngredient.PizzaId, pizzaIngredients.PizzaId);
            Assert.Equal(pizzaIngredient.IngredientId, pizzaIngredients.IngredientId);
        }

        [Fact]
        public void UserToUsersTest()
        {
            User user = new User()
            {
                Id = 1,
                Name = "UserName",
                Password = "Password",
                UserType = new UserType
                {
                    Id = 1,
                    Name = "Name"
                },
                Address = new Address()
                {
                    Id = 1,
                    Street = "Street",
                    City = "City",
                    State = "State",
                    ZipCode = "ZipCode"
                }
            };

            Users users = mapper.MapUser(user);

            Assert.Equal(user.Id, users.Id);
            Assert.Equal(user.Name, users.Name);
            Assert.Equal(user.UserType.Id, users.UserTypeId);
            Assert.Equal(user.Address.Id, users.AddressId);

            //Assert.Equal(user.UserType.Id, users.UserType.Id);
            //Assert.Equal(user.UserType.Name, users.UserType.Name);

            //Assert.Equal(user.Address.Id, users.Address.Id);
            //Assert.Equal(user.Address.Street, users.Address.Street);
            //Assert.Equal(user.Address.City, users.Address.City);
            //Assert.Equal(user.Address.State, users.Address.State);
            //Assert.Equal(user.Address.ZipCode, users.Address.ZipCode);
        }
    }
}
