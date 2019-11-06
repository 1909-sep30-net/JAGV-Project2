using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project2JAGV.ObjectLogic.Interfaces
{
    public interface IDataAccess : IDisposable
    {
        public Task AddAddressAsync(Address address);
        public Task<ICollection<Address>> GetAddressesAsync(int? id = null);
        public Task AddIngredientAsync(Ingredient ingredient);
        public Task<ICollection<Ingredient>> GetIngredientsAsync(int? id = null, int? typeId = null);
        public Task AddIngredientTypeAsync(IngredientType ingredientType);
        public Task<ICollection<IngredientType>> GetIngredientsTypeAsync(int? id = null, string name = null);
        public Task AddOrderAsync(Order order);
        public Task<ICollection<Order>> GetOrdersAsync(int? id = null, int? userId = null, int? delivererId = null);
        public Task AddPizzaAsync(Pizza pizza);
        public Task<ICollection<Pizza>> GetPizzasAsync(int? id = null, string name = null);
        public Task AddPizzaIngredientAsync(PizzaIngredient pizzaIngredient);
        public Task<ICollection<PizzaIngredient>> GetPizzaIngredientsAsync(int? id = null, int? pizzaId = null, int? IngredientId = null);
        public Task AddUserAsync(User user);
        public Task<ICollection<User>> GetUsersAsync(int? id = null, string name = null);
        public Task AddUserTypeAsync(UserType userType);
        public Task<ICollection<UserType>> GetUserTypesAsync(int? id = null, string name = null);
        public Task SaveAsync();
    }
}
