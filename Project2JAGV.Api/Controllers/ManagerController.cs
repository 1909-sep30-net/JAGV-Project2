using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project2JAGV.Api.Models;
using Project2JAGV.ObjectLogic;
using Project2JAGV.ObjectLogic.Interfaces;

namespace Project2JAGV.Api.Controllers
{
    [Route("api/managers")]
    [Authorize]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IDataAccess db;

        public ManagerController(IDataAccess dataAccess)
        {
            db = dataAccess;
        }

        // GET: api/Users
        [Route("users")]
        [HttpGet]
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
