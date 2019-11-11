using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project2JAGV.Api.Models;
using Project2JAGV.ObjectLogic;
using Project2JAGV.ObjectLogic.Interfaces;

namespace Project2JAGV.Api.Controllers
{
    [Route("api/managers")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IDataAccess db;

        public ManagerController(IDataAccess dataAccess)
        {
            db = dataAccess;
        }

        // GET: api/Manager
        [HttpGet]
        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };
        }

        // GET: api/Manager/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // GET: api/Users
        [Route("users")]
        [HttpGet("users", Name = "allUsers")]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUsers()
        {
            IEnumerable<User> dbUsers = await db.GetUsersAsync();
            return dbUsers.Select(u => new UserModel
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
            }).ToList();
        }
    }
}
