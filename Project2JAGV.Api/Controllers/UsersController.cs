﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project2JAGV.Api.Models;
using Project2JAGV.ObjectLogic;
using Project2JAGV.ObjectLogic.Interfaces;

namespace Project2JAGV.Api.Controllers
{
    [Route("users")]
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

        // GET: api/Users/5
        [Route("{id}")]
        [HttpGet(Name = "Get")]
        public async Task<IEnumerable<UserModel>> Get(int id)
        {
            IEnumerable<User> dbUsers = await db.GetUsersAsync(id: id);
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

        // GET: api/Users/5/addressId
        [Route("{id}/address")]
        [HttpGet(Name = "GetAddress")]
        public async Task<AddressModel> GetAddress(int id)
        {
            User dbUsers = (await db.GetUsersAsync(id: id)).First();
            return new AddressModel
            {
                Id = dbUsers.Address.Id,
                Street = dbUsers.Address.Street,
                City = dbUsers.Address.City,
                State = dbUsers.Address.State,
                ZipCode = dbUsers.Address.ZipCode,
            };
        }

        // GET: api/Users/5/orders
        [Route("{id}/orders")]
        [HttpGet(Name = "GetOrders")]
        public async Task<IEnumerable<OrderModel>> GetOrders(int id)
        {
            User dbUsers = (await db.GetUsersAsync(id: id)).First();
            return dbUsers.Orders.Select(o => new OrderModel
            {
                Id = o.Id,
                UserId = o.UserId,
                DelivererId = o.DelivererId,
                Delivered = o.Delivered,
                Date = o.Date
            });
        }

        //POST: api/Users
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserModel user)
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

            return CreatedAtRoute("Get", new {userModel.Id}, userModel);
        }
    }
}
