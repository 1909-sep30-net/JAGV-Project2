using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project2JAGV.Api.Models;
using Project2JAGV.ObjectLogic;
using Project2JAGV.ObjectLogic.Interfaces;
using Serilog;

namespace Project2JAGV.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDataAccess db;
        
        public UsersController(IDataAccess dataAccess)
        {
            db = dataAccess;
        }

        [Route("login/{name}")]
        [HttpGet("login/{name}", Name = "GetLogin")]
        public async Task<ActionResult<UserModel>> GetLogin(string name)
        {
            User user = (await db.GetUsersAsync(name: name)).FirstOrDefault();
            if (user == null)
            {
                Log.Error("Username: {name} not found");

                return NotFound();
            }

            UserModel userModel = new UserModel
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                UserType = new UserTypeModel
                {
                    Id = user.UserType.Id,
                    Name = user.UserType.Name,
                },
                Address = new AddressModel
                {
                    Id = user.Address.Id,
                    Street = user.Address.Street,
                    City = user.Address.City,
                    State = user.Address.State,
                    ZipCode = user.Address.ZipCode,
                }
            };

            Log.Information("Got login for {name}");
            return Ok(userModel);
        }

        // GET: api/Users/5
        [Route("{id}")]
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<UserModel>> Get(int id)
        {
            User user = (await db.GetUsersAsync(id: id)).FirstOrDefault();

            if (user == null)
            {
                Log.Error("User not found");
                return NotFound();
            }

            Log.Information("Got user");
            return Ok(new UserModel
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                UserType = new UserTypeModel
                {
                    Id = user.UserType.Id,
                    Name = user.UserType.Name,
                },
                Address = new AddressModel
                {
                    Id = user.Address.Id,
                    Street = user.Address.Street,
                    City = user.Address.City,
                    State = user.Address.State,
                    ZipCode = user.Address.ZipCode,
                },
            });
        }

        // GET: api/Users/5/addressId
        [Route("{id}/address")]
        [HttpGet("{id}/address", Name = "GetAddress")]
        public async Task<ActionResult<AddressModel>> GetAddress(int id)
        {
            User user = (await db.GetUsersAsync(id: id)).FirstOrDefault();

            if (user == null)
            {
                Log.Error("Address not found");
                return NotFound();
            }

            Log.Information("Found user address");
            return Ok(new AddressModel
            {
                Id = user.Address.Id,
                Street = user.Address.Street,
                City = user.Address.City,
                State = user.Address.State,
                ZipCode = user.Address.ZipCode,
            });
        }

        // GET: api/Users/5/orders
        [Route("{id}/orders")]
        [HttpGet("{id}/orders", Name = "GetOrders")]
        public async Task<ActionResult<IEnumerable<OrderModel>>> GetOrders(int id)
        {
            User user = (await db.GetUsersAsync(id: id)).FirstOrDefault();
            if (user == null)
            {
                Log.Error("Orders not found");
                return NotFound();
            }

            return Ok(user.Orders.Select(o => new OrderModel
            {
                Id = o.Id,
                UserId = o.UserId,
                DelivererId = o.DelivererId,
                Delivered = o.Delivered,
                Date = o.Date,
                Pizzas = o.Pizzas.Select(p => new PizzaModel
                {
                    Id = p.Id,
                    OrderId = p.OrderId,
                    Name = p.Name,
                    pi = p.PizzaIngredients.Select(pi => new PizzaIngredientModel
                    {
                        Id = pi.Id,
                        PizzaId = pi.PizzaId,
                        IngredientId = pi.IngredientId,
                        Ingredient = new IngredientModel
                        {
                            Id = pi.Ingredient.Id,
                            Name = pi.Ingredient.Name,
                            Price = pi.Ingredient.Price,
                            TypeId = pi.Ingredient.TypeId,
                            IngredientType = new IngredientTypeModel
                            {
                                Id = pi.Ingredient.IngredientType.Id,
                                Name = pi.Ingredient.IngredientType.Name,
                            },
                        },
                    }).ToList(),
                }).ToList(),
            }));
        }

        [HttpPost]
        public async Task<ActionResult> PostUser([FromBody] UserModel user)
        {
            User newUser = new User
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                UserType = new UserType
                {
                    Id = user.UserType.Id,
                    Name = user.UserType.Name,
                },
                Address = new Address
                {
                    Id = user.Address.Id,
                    Street = user.Address.Street,
                    City = user.Address.City,
                    State = user.Address.State,
                    ZipCode = user.Address.ZipCode,
                }
            };

            try
            {
                await db.AddUserAsync(newUser);
                await db.SaveAsync();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest($"{ex.Message}");
            }

            newUser = (await db.GetUsersAsync(name: newUser.Name)).First();
            UserModel userModel = new UserModel
            {
                Id = newUser.Id,
                Name = newUser.Name,
                Password = newUser.Password,
                UserType = new UserTypeModel
                {
                    Id = newUser.UserType.Id,
                    Name = newUser.UserType.Name,
                },
                Address = new AddressModel
                {
                    Id = newUser.Address.Id,
                    Street = newUser.Address.Street,
                    City = newUser.Address.City,
                    State = newUser.Address.State,
                    ZipCode = newUser.Address.ZipCode,
                },
            };

            Log.Information("New user {name}");
            return CreatedAtRoute("Get", new { userModel.Id }, userModel);
        }

        [Route("ingredients")]
        [HttpGet("ingredients", Name = "GetIngredients")]
        public async Task<ActionResult<IEnumerable<IngredientModel>>> GetIngredients()
        {
            IEnumerable<Ingredient> ingredients = await db.GetIngredientsAsync();

            IEnumerable<IngredientModel> ingredientModels = ingredients.Select(i => new IngredientModel
            {
                Id = i.Id,
                TypeId = i.TypeId,
                Name = i.Name,
                Price = i.Price,
                IngredientType = new IngredientTypeModel
                {
                    Id = i.IngredientType.Id,
                    Name = i.IngredientType.Name,
                }
            });

            Log.Information("Got all ingredients");
            return Ok(ingredientModels);
        }

        // POST: api/Orders
        [Route("{id}/place-order")]
        [HttpPost("{id}/place-order", Name = "PostOrder")]
        public async Task<ActionResult> PostOrder(int id, [FromBody] OrderModel order)
        {
            DateTime newDate = DateTime.Now;

            Order newOrder = new Order
            {
                Id = 0,
                UserId = id,
                DelivererId = 0,
                Delivered = false,
                Date = newDate,
                Pizzas = order.Pizzas.Select(p => new Pizza
                {
                    Id = 0,
                    OrderId = 0,
                    Name = p.Name,
                    PizzaIngredients = p.pi.Select(pi => new PizzaIngredient
                    {
                        Id = 0,
                        PizzaId = 0,
                        IngredientId = pi.IngredientId,
                    }).ToList(),
                }).ToList(),
            };

            try
            {
                await db.AddOrderAsync(newOrder);
                await db.SaveAsync();
            }
            catch
            {
                Log.Error("Unable to add order");
                return BadRequest("Something went wrong");
            }

            newOrder = (await db.GetOrdersAsync(date: newDate)).First();
            return CreatedAtRoute("Get", new { newOrder.Id }, newOrder);
        }
    }
}
