using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project2JAGV.Api.Models;
using Project2JAGV.ObjectLogic;
using Project2JAGV.ObjectLogic.Interfaces;

namespace Project2JAGV.Api.Controllers
{
    [Route("api/drivers")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IDataAccess db;

        public DriverController(IDataAccess dataAccess)
        {
            db = dataAccess;
        }

        // GET: api/Driver
        [Route("all")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> Get()
        {
            IEnumerable<User> drivers = (await db.GetDriversAsync()).ToList();

            return Ok(drivers.Select(u => new UserModel
            {
                Id = u.Id,
                Name = u.Name,
                Password = u.Password,
                UserType = new UserTypeModel
                {
                    Id = u.UserType.Id,
                    Name = u.UserType.Name,
                },
                Address = new AddressModel
                {
                    Id = u.Address.Id,
                    Street = u.Address.Street,
                    City = u.Address.City,
                    State = u.Address.State,
                    ZipCode = u.Address.ZipCode,
                },
            }).ToList());
        }

        // GET: api/Driver/5
        [Route("{id}")]
        [HttpGet]
        public async Task<UserModel> Get(int id)
        {
            User dbUsers = (await db.GetUsersAsync(id: id)).FirstOrDefault();

            return new UserModel
            {
                Id = dbUsers.Id,
                Name = dbUsers.Name,
                Password = dbUsers.Password,
                UserType = new UserTypeModel
                {
                    Id = dbUsers.UserType.Id,
                    Name = dbUsers.UserType.Name,
                },
                Address = new AddressModel
                {
                    Id = dbUsers.Address.Id,
                    Street = dbUsers.Address.Street,
                    City = dbUsers.Address.City,
                    State = dbUsers.Address.State,
                    ZipCode = dbUsers.Address.ZipCode,
                },
            };
        }

        // GET: api/drivers/5/orders
        [Route("{id}/orders")]
        [HttpGet]
        public async Task<IEnumerable<OrderModel>> GetOrders(int id)
        {
            IEnumerable<Order> orders = (await db.GetOrdersAsync(delivered: false)).ToList();

            return orders.Select(o => new OrderModel
            {
                Id = o.Id,
                UserId = o.UserId,
                DelivererId = id,
                Delivered = true,
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
            });
        }
    }
}
