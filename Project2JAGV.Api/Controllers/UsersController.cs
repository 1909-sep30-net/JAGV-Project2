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
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDataAccess db;
        
        private readonly ILogger<UsersController> _logger;

        public UsersController(IDataAccess dataAccess, ILogger<UsersController> logger)
        {
            db = dataAccess;
            _logger = logger;
            _logger.LogInformation("Starting");
        }

        // GET: api/Users
        [Route("all")]
        [HttpGet]
        public async Task<IEnumerable<UserModel>> Get()
        {
            IEnumerable<User> dbUsers = await db.GetUsersAsync();
            return dbUsers.Select(u => new UserModel
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName
            }).ToList();

        }

        // GET: api/Users/5
        [Route("{id}")]
        [HttpGet(Name = "Get")]
        public async Task<IEnumerable<UserModel>> Get(int _id)
        {
            IEnumerable<User> dbUsers = await db.GetUsersAsync(id: _id);
            return dbUsers.Select(u => new UserModel
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName
            }).ToList();
        }

        // GET: api/Users/5/addressId
        [Route("{id}/address")]
        [HttpGet(Name = "GetAddress")]
        public async Task<AddressModel> GetAddress(int _id)
        {
            User dbUsers = (await db.GetUsersAsync(id: _id)).First();
            return new AddressModel
            {
                Id = dbUsers.Address.Id,
                Street = dbUsers.Address.Street,
                City = dbUsers.Address.City,
                State = dbUsers.Address.State,
                ZipCode = dbUsers.Address.ZipCode

            };
        }

        // GET: api/Users/5/orders
        [Route("{id}/orders")]
        [HttpGet(Name = "GetOrders")]
        public async Task<IEnumerable<OrderModel>> GetOrders(int _id)
        {
            User dbUsers = (await db.GetUsersAsync(id: _id)).First();
            return dbUsers.Orders.Select(o => new OrderModel
            {

                Id = o.Id,
                UserId = o.UserId,
                DelivererId = o.DelivererId,
                Delivered = o.Delivered,
                Date = o.Date
            });

            
        }




        // POST: api/Users
        // [HttpPost]
        //public ActionResult Post([FromBody, Bind("Id, FirstName, LastName")] UserModel user)
        //{
        //    return CreatedAtRoute("Get", new {});
        //}

        // PUT: api/Users/5
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
