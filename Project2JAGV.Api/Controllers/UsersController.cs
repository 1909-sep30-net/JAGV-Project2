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

        public UsersController(IDataAccess dataAccess)
        {
            db = dataAccess;
        }
        
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
            _logger.LogInformation("Starting");
        }

        // GET: api/Users
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
        [HttpGet("{id}", Name = "Get")]
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

        // POST: api/Users
        [HttpPost]
        public ActionResult Post([FromBody, Bind("Id, FirstName, LastName")] UserModel user)
        {
            return CreatedAtRoute("Get", new {});
        }

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
