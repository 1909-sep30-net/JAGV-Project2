using Microsoft.AspNetCore.Mvc;
using Project2JAGV.Api.Controllers;
using Project2JAGV.Api.Models;
using Project2JAGV.DataAccess.Entities;
using Project2JAGV.ObjectLogic;
using Project2JAGV.ObjectLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Project2JAGV.Test.ControllerTests
{
    public class ControllerMoqTests
    {
        [Fact]
        public void ShouldGetUserById()
        {
            // arrange
            var stubRepo = new DataAccessStub();
            var controller = new UsersController(stubRepo);
            // should not test against the real repo - that would not be a unit test.

            // act
            var result = controller.Get(5);

            // assert
            
            Assert.NotNull(result);
        }

        public class DataAccessStub : IDataAccess
        {
            public User GetUsersById(int id)
            {
                return new User
                {
                    Id = 5,
                    Name = "Abc"
                };
            }

            public Task AddAddressAsync(Address address) { throw new NotImplementedException(); }
            public Task<ICollection<Address>> GetAddressesAsync(int? id = null, Address address = null) { throw new NotImplementedException(); }
            public Task AddIngredientAsync(Ingredient ingredient) { throw new NotImplementedException(); }
            public Task<ICollection<Ingredient>> GetIngredientsAsync(int? id = null, int? typeId = null, string name = null) { throw new NotImplementedException(); }
            public Task AddIngredientTypeAsync(IngredientType ingredientType) { throw new NotImplementedException(); }
            public Task<ICollection<IngredientType>> GetIngredientTypesAsync(int? id = null, string name = null) { throw new NotImplementedException(); }
            public Task AddOrderAsync(Order order) { throw new NotImplementedException(); }
            public Task<ICollection<Order>> GetOrdersAsync(int? id = null, int? userId = null, int? delivererId = null, bool? delivered = null, DateTime? date = null) { throw new NotImplementedException(); }
            public Task AddPizzaAsync(Pizza pizza) { throw new NotImplementedException(); }
            public Task<ICollection<Pizza>> GetPizzasAsync(int? id = null, int? orderId = null, string name = null) { throw new NotImplementedException(); }
            public Task AddPizzaIngredientAsync(PizzaIngredient pizzaIngredient) { throw new NotImplementedException(); }
            public Task<ICollection<PizzaIngredient>> GetPizzaIngredientsAsync(int? id = null, int? pizzaId = null, int? IngredientId = null) { throw new NotImplementedException(); }
            public Task AddUserAsync(User user) { throw new NotImplementedException(); }
            public Task<ICollection<User>> GetUsersAsync(int? id = null, string name = null) {

                return Task.Run(() =>
                {
                    ICollection<User> weenie = new List<User> {
                    new User {
                    Id  = 5,
                    Name = "Abc" }
                    };

                    return weenie;
                });
                
                }
            public Task AddUserTypeAsync(UserType userType) { throw new NotImplementedException(); }
            public Task<ICollection<UserType>> GetUserTypesAsync(int? id = null, string name = null) { throw new NotImplementedException(); }
            public Task<ICollection<User>> GetDriversAsync() { throw new NotImplementedException(); }
            public Task SaveAsync() { throw new NotImplementedException(); }

            #region IDisposable Support
            private bool _disposedValue = false; // To detect redundant calls

            protected virtual void Dispose(bool disposing)
            {
                if (!_disposedValue)
                {
                    if (disposing)
                    {
                        
                    }

                    _disposedValue = true;
                }
            }

            // This code added to correctly implement the disposable pattern.
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            #endregion

        }
    }
}
