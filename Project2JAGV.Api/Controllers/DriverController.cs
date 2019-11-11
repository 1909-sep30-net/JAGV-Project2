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
        public async Task<ActionResult<IEnumerable<AddressModel>>> GetOrders(int id)
        {
            IEnumerable<Order> orders = (await db.GetOrdersAsync(delivered: false)).ToList();
            IEnumerable<User> users = (await db.GetUsersAsync()).ToList();

            List<AddressModel> addresses = new List<AddressModel>();

            foreach (Order o in orders)
            {
                User u = users.First(u => u.Id == o.UserId);

                o.DelivererId = id;
                o.Delivered = true;
                await db.UpdateOrderAsync(o);
                await db.SaveAsync();

                addresses.Add(new AddressModel
                {
                    Id = u.Address.Id,
                    Street = u.Address.Street,
                    City = u.Address.City,
                    State = u.Address.State,
                    ZipCode = u.Address.ZipCode,
                });
            }

            return addresses;
        }
    }
}
