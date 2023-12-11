using System;
using test6.DB;
using test6.Models;
using test6.Repository.ClientRepository;
using test6.Repository.OrderRepository;
using test6.Repository.GenericRepository;
using test6.Repository.ProductRepository;
using test6.Repository.StoreRepository;

namespace test6.Services.IUnitOfWork
{
	public class UnitOfWork:IUnitOfWork
	{
        private readonly DBContext _context;
        private IGenericRepository<Client> _client;
        private IGenericRepository<Order> _order;
        private IGenericRepository<Product> _product;
        private IGenericRepository<Store> _store;

        public UnitOfWork(DBContext context)
		{
            _context = context;
		}

        public IGenericRepository<Client> Client => _client ?? new ClientRepository(_context);
        public IGenericRepository<Order> Order => _order ?? new OrderRepository(_context);
        public IGenericRepository<Product> Product => _product ?? new ProductRepository(_context);
        public IGenericRepository<Store> Store => _store ?? new StoreRepository(_context);


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}

