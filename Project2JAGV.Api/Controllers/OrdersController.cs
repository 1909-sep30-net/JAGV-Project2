using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project2JAGV.Api.Models;
using Project2JAGV.ObjectLogic;
using Project2JAGV.ObjectLogic.Interfaces;

namespace Project2JAGV.Api.Controllers
{
    [Route("orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IDataAccess db;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IDataAccess dataAccess, ILogger<OrdersController> logger)
        {
            db = dataAccess;
            _logger = logger;
            _logger.LogInformation("Starting");
        }

        // GET: api/Orders
        [Route("all")]
        [HttpGet]
        public async Task<IEnumerable<OrderModel>> GetAll()
        {
            IEnumerable<Order> dbUsers = await db.GetOrdersAsync();
            return dbUsers.Select(o => new OrderModel
            {
                Id = o.Id,
                UserId = o.UserId,
                Delivered = o.Delivered,
                DelivererId = o.DelivererId,
                Date = o.Date,
                pizzas = o.Pizzas.Select(p => new PizzaModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    OrderId = p.OrderId,
                    pi = p.PizzaIngredients.Select(i => new PizzaIngredientModel
                    {
                        Id = i.Id,
                        PizzaId = i.PizzaId,
                        IngredientId = i.IngredientId,
                        Ingredient = new IngredientModel
                        {
                            Id = i.Ingredient.Id,
                            TypeId = i.Ingredient.TypeId,
                            Name = i.Ingredient.Name,
                            Price = i.Ingredient.Price,
                            IngredientType = new IngredientTypeModel
                            {
                                Id = i.Ingredient.IngredientType.Id,
                                Name = i.Ingredient.IngredientType.Name
                            }
                        }
                    }).ToList(),
                }).ToList(),


            }).ToList();
        }

        // GET: api/Orders/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Orders
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
