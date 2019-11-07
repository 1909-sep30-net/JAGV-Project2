using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project2JAGV.DataAccess.Entities;
using Project2JAGV.ObjectLogic;
using Project2JAGV.ObjectLogic.Interfaces;

namespace Project2JAGV.DataAccess
{
    public class DataAccess : IDataAccess
    {
        private readonly Project2JAGVContext _context;

        /// <summary>
        /// constructor for the project0 database access
        /// </summary>
        /// <param name="context">Dbcontext for accessing the database</param>
        public DataAccess(Project2JAGVContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAddressAsync(Address address)
        {
            Entities.Addresses addresses = Mappers.MapAddress(address);

            await _context.AddAsync(addresses);
        }

        public async Task<ICollection<Address>> GetAddressesAsync(int? id = null, Address address = null)
        {
            List<Addresses> addresses = await _context.Addresses.AsNoTracking().ToListAsync();

            if (id != null)
                addresses = addresses.Where(a => a.Id == id).ToList();
            if (address != null)
            {
                addresses = addresses.Where(a => a.Street == address.Street && a.City == address.City && a.State == address.State && a.ZipCode == address.ZipCode).ToList();
            }
            return addresses.Select(Mappers.MapAddress).ToList();
        }

        public async Task AddIngredientAsync(Ingredient ingredient)
        {
            Ingredients ingredients = Mappers.MapIngredient(ingredient);

            await _context.AddAsync(ingredients);
        }

        public async Task<ICollection<Ingredient>> GetIngredientsAsync(int? id = null, int? typeId = null)
        {
            List<Ingredients> ingredients = await _context.Ingredients.Include(i => i.IngredientType).AsNoTracking().ToListAsync();

            if (id != null)
                ingredients = ingredients.Where(i => i.Id == id).ToList();
            if (typeId != null)
                ingredients = ingredients.Where(i => i.TypeId == typeId).ToList();

            return ingredients.Select(Mappers.MapIngredient).ToList();
        }

        public async Task AddIngredientTypeAsync(IngredientType ingredientType)
        {
            IngredientTypes ingredientTypes = Mappers.MapIngredientType(ingredientType);

            await _context.AddAsync(ingredientTypes);
        }

        public async Task<ICollection<IngredientType>> GetIngredientsTypeAsync(int? id = null, string name = null)
        {
            List<IngredientTypes> ingredientTypes = await _context.IngredientTypes.AsNoTracking().ToListAsync();

            if (id != null)
                ingredientTypes = ingredientTypes.Where(it => it.Id == id).ToList();
            if (name != null)
                ingredientTypes = ingredientTypes.Where(it => it.Name == name).ToList();

            return ingredientTypes.Select(Mappers.MapIngredientType).ToList();
        }

        public async Task AddOrderAsync(Order order)
        {
            Orders orders = Mappers.MapOrder(order);

            await _context.AddAsync(orders);
        }

        public async Task<ICollection<Order>> GetOrdersAsync(int? id = null, int? userId = null, int? delivererId = null)
        {
            List<Orders> orders = await _context.Orders
                .Include(o => o.Pizzas)
                    .ThenInclude(p => p.PizzaIngredients)
                        .ThenInclude(pi => pi.Ingredient)
                            .ThenInclude(i => i.IngredientType)
                .AsNoTracking().ToListAsync();

            if (id != null)
                orders = orders.Where(o => o.Id == id).ToList();
            if (userId != null)
                orders = orders.Where(o => o.UserId == userId).ToList();
            if (delivererId != null)
                orders = orders.Where(o => o.DelivererId == delivererId).ToList();

            return orders.Select(Mappers.MapOrder).ToList();
        }

        public async Task AddPizzaAsync(Pizza pizza)
        {
            Pizzas pizzas = Mappers.MapPizza(pizza);

            await _context.AddAsync(pizzas);
        }

        public async Task<ICollection<Pizza>> GetPizzasAsync(int? id = null, string name = null)
        {
            List<Pizzas> pizzas = await _context.Pizzas
                .Include(p => p.PizzaIngredients)
                    .ThenInclude(pi => pi.Ingredient)
                        .ThenInclude(i => i.IngredientType)
                .AsNoTracking().ToListAsync();

            if (id != null)
                pizzas = pizzas.Where(p => p.Id == id).ToList();
            if (name != null)
                pizzas = pizzas.Where(p => p.Name == name).ToList();

            return pizzas.Select(Mappers.MapPizza).ToList();
        }

        public async Task AddPizzaIngredientAsync(PizzaIngredient pizzaIngredient)
        {
            PizzaIngredients pizzaIngredients = Mappers.MapPizzaIngredient(pizzaIngredient);

            await _context.AddAsync(pizzaIngredients);
        }

        public async Task<ICollection<PizzaIngredient>> GetPizzaIngredientsAsync(int? id = null, int? pizzaId = null, int? IngredientId = null)
        {
            List<PizzaIngredients> pizzaIngredients = await _context.PizzaIngredients
                .Include(pi => pi.Ingredient)
                    .ThenInclude(i => i.IngredientType)
                .AsNoTracking().ToListAsync();

            if (id != null)
                pizzaIngredients = pizzaIngredients.Where(pi => pi.Id == id).ToList();
            if (pizzaId != null)
                pizzaIngredients = pizzaIngredients.Where(pi => pi.PizzaId == pizzaId).ToList();
            if (IngredientId != null)
                pizzaIngredients = pizzaIngredients.Where(pi => pi.IngredientId == IngredientId).ToList();

            return pizzaIngredients.Select(Mappers.MapPizzaIngredient).ToList();
        }

        public async Task AddUserAsync(User user)
        {
            Users users = Mappers.MapUser(user);

            await _context.AddAsync(users);
        }

        public async Task<ICollection<User>> GetUsersAsync(int? id = null, string name = null)
        {
            List<Users> users = await _context.Users
                .Include(u => u.Address)
                .Include(l => l.UserType)
                .Include(u => u.Orders)
                    .ThenInclude(o => o.Pizzas)
                        .ThenInclude(p => p.PizzaIngredients)
                            .ThenInclude(pi => pi.Ingredient)
                                .ThenInclude(i => i.IngredientType)
                 .AsNoTracking().ToListAsync();

            if (id != null)
                users = users.Where(u => u.Id == id).ToList();
            if (name != null)
                users = users.Where(u => u.Name == name).ToList();

            return users.Select(Mappers.MapUser).ToList();
        }

        public async Task AddUserTypeAsync(UserType userType)
        {
            UserTypes userTypes = Mappers.MapUserType(userType);

            await _context.AddAsync(userTypes);
        }

        public async Task<ICollection<UserType>> GetUserTypesAsync(int? id = null, string name = null)
        {
            List<UserTypes> userTypes = await _context.UserTypes.AsNoTracking().ToListAsync();

            if (id != null)
                userTypes = userTypes.Where(ut => ut.Id == id).ToList();
            if (name != null)
                userTypes = userTypes.Where(ut => ut.Name == name).ToList();

            return userTypes.Select(Mappers.MapUserType).ToList();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        #region IDisposable Support
        private bool _disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
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
