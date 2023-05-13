using OnlineStoreApp.Interfaces;
using OnlineStoreApp.Models;
using OnlineStoreApp.Settings;

namespace OnlineStoreApp.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _context;
        private IRepository<User>? _users;
        private IRepository<Order>? _orders;
        private IRepository<Item>? _items;
        private IRepository<Product>? _products;

        public UnitOfWork(StoreDbContext context)
        {
            _context = context;
        }

        public IRepository<User> Users => _users ??= new Repository<User>(_context);

        public IRepository<Order> Orders => _orders ??= new Repository<Order>(_context);

        public IRepository<Item> Items => _items ??= new Repository<Item>(_context);

        public IRepository<Product> Products => _products ??= new Repository<Product>(_context);

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
