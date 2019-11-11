using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project2JAGV.DataAccess.Entities;
using Project2JAGV.DataAccess.Interfaces;
using Project2JAGV.ObjectLogic;
using Project2JAGV.ObjectLogic.Interfaces;

namespace Project2JAGV.DataAccess
{
    public class DataAccess : IDataAccess
    {
        private readonly IMappers _mapper;
        private readonly Project2JAGVContext _context;

        /// <summary>
        /// constructor for the project0 database access
        /// </summary>
        /// <param name="context">Dbcontext for accessing the database</param>
        public DataAccess(Project2JAGVContext context, IMappers mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task AddAddressAsync(Address address)
        {
            Address newAddress = (await GetAddressesAsync(address: address)).FirstOrDefault();
            if (newAddress == null)
            {
                address.Id = 0;
                await _context.AddAsync(_mapper.MapAddress(address));
            }
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
            return addresses.Select(_mapper.MapAddress).ToList();
        }

        public async Task AddIngredientAsync(Ingredient ingredient)
        {
            IngredientType newIngredientType = (await GetIngredientTypesAsync(name: ingredient.IngredientType.Name)).FirstOrDefault();
            if (newIngredientType == null)
            {
                ingredient.IngredientType.Id = 0;
                await AddIngredientTypeAsync(ingredient.IngredientType);
            }

            Ingredient newIngredient = (await GetIngredientsAsync(name: ingredient.Name)).FirstOrDefault();
            if (newIngredient == null)
            {
                ingredient.Id = 0;
                await _context.AddAsync(_mapper.MapIngredient(ingredient));
            }
        }

        public async Task<ICollection<Ingredient>> GetIngredientsAsync(int? id = null, int? typeId = null, string name = null)
        {
            List<Ingredients> ingredients = await _context.Ingredients.Include(i => i.IngredientType).AsNoTracking().ToListAsync();

            if (id != null)
                ingredients = ingredients.Where(i => i.Id == id).ToList();
            if (typeId != null)
                ingredients = ingredients.Where(i => i.TypeId == typeId).ToList();
            if (name != null)
                ingredients = ingredients.Where(i => i.Name == name).ToList();

            return ingredients.Select(_mapper.MapIngredient).ToList();
        }

        public async Task AddIngredientTypeAsync(IngredientType ingredientType)
        {
            IngredientType newIngredientType = (await GetIngredientTypesAsync(name: ingredientType.Name)).FirstOrDefault();
            if (newIngredientType == null)
            {
                ingredientType.Id = 0;
                await _context.AddAsync(_mapper.MapIngredientType(ingredientType));
            }
        }

        public async Task<ICollection<IngredientType>> GetIngredientTypesAsync(int? id = null, string name = null)
        {
            List<IngredientTypes> ingredientTypes = await _context.IngredientTypes.AsNoTracking().ToListAsync();

            if (id != null)
                ingredientTypes = ingredientTypes.Where(it => it.Id == id).ToList();
            if (name != null)
                ingredientTypes = ingredientTypes.Where(it => it.Name == name).ToList();

            return ingredientTypes.Select(_mapper.MapIngredientType).ToList();
        }

        public async Task AddOrderAsync(Order order)
        {
            order.Id = 0;
            foreach (Pizza p in order.Pizzas)
            {
                p.Id = 0;
                p.OrderId = 0;
                foreach (PizzaIngredient pi in p.PizzaIngredients)
                {
                    pi.Id = 0;
                    pi.PizzaId = 0;
                }
            }

            await _context.AddAsync(_mapper.MapOrder(order));
        }

        public async Task<ICollection<Order>> GetOrdersAsync(int? id = null, int? userId = null, int? delivererId = null, bool? delivered = null, DateTime? date = null)
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
            if (delivered != null)
                orders = orders.Where(o => o.Delivered == delivered).ToList();
            if (date != null)
                orders = orders.Where(o => o.Date == date).ToList();

            return orders.Select(_mapper.MapOrder).ToList();
        }

        // dont think we need this
        public async Task AddPizzaAsync(Pizza pizza)
        {
            pizza.Id = 0;
            foreach (PizzaIngredient pi in pizza.PizzaIngredients)
            {
                pi.Id = 0;
                pi.PizzaId = 0;
            }

            await _context.AddAsync(_mapper.MapPizza(pizza));
        }

        public async Task<ICollection<Pizza>> GetPizzasAsync(int? id = null, int? orderId = null, string name = null)
        {
            List<Pizzas> pizzas = await _context.Pizzas
                .Include(p => p.PizzaIngredients)
                    .ThenInclude(pi => pi.Ingredient)
                        .ThenInclude(i => i.IngredientType)
                .AsNoTracking().ToListAsync();

            if (id != null)
                pizzas = pizzas.Where(p => p.Id == id).ToList();
            if (orderId != null)
                pizzas = pizzas.Where(p => p.OrderId == orderId).ToList();
            if (name != null)
                pizzas = pizzas.Where(p => p.Name == name).ToList();
            
            return pizzas.Select(_mapper.MapPizza).ToList();
        }

        // dont think we need this
        public async Task AddPizzaIngredientAsync(PizzaIngredient pizzaIngredient)
        {
            PizzaIngredient newPizzaIngredient = (await GetPizzaIngredientsAsync(pizzaId: pizzaIngredient.PizzaId, IngredientId: pizzaIngredient.IngredientId)).FirstOrDefault();
            if (newPizzaIngredient == null)
            {
                pizzaIngredient.Id = 0;
                await _context.AddAsync(_mapper.MapPizzaIngredient(pizzaIngredient));
            }
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

            return pizzaIngredients.Select(_mapper.MapPizzaIngredient).ToList();
        }

        public async Task AddUserAsync(User user)
        {
            User newUser = (await GetUsersAsync(name: user.Name)).FirstOrDefault();
            if (newUser != null)
            {
                throw new InvalidOperationException("User name allready in use");
            }

            user.Id = 0;
            await AddUserTypeAsync(user.UserType);
            await SaveAsync();
            user.UserType = (await GetUserTypesAsync(name: user.UserType.Name)).First();

            await AddAddressAsync(user.Address);
            await SaveAsync();
            user.Address = (await GetAddressesAsync(address: user.Address)).First();

            await _context.AddAsync(_mapper.MapUser(user));
        }

        public async Task<ICollection<User>> GetUsersAsync(int? id = null, string name = null, string password = null)
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
            if (password != null)
                users = users.Where(u => u.Password == password).ToList();

            return users.Select(_mapper.MapUser).ToList();
        }

        public async Task AddUserTypeAsync(UserType userType)
        {
            UserType newUserType = (await GetUserTypesAsync(name: userType.Name)).FirstOrDefault();
            if (newUserType == null)
            {
                userType.Id = 0;
                await _context.AddAsync(_mapper.MapUserType(userType));
            }
        }

        public async Task<ICollection<UserType>> GetUserTypesAsync(int? id = null, string name = null)
        {
            List<UserTypes> userTypes = await _context.UserTypes.AsNoTracking().ToListAsync();

            if (id != null)
                userTypes = userTypes.Where(ut => ut.Id == id).ToList();
            if (name != null)
                userTypes = userTypes.Where(ut => ut.Name == name).ToList();

            return userTypes.Select(_mapper.MapUserType).ToList();
        }

        public async Task<ICollection<User>> GetDriversAsync()
        {
            ICollection<User> drivers = await GetUsersAsync();
            
            drivers = drivers.Where(d => d.UserType.Name == "Driver").ToList();

            return drivers;
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
