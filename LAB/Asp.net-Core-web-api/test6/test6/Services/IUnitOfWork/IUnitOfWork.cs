using System;
using test6.Models;
using test6.Repository.GenericRepository;

namespace test6.Services.IUnitOfWork
{
	public interface IUnitOfWork:IDisposable
	{
		IGenericRepository<Client> Client { get;}
		IGenericRepository<Order> Order { get;}
		IGenericRepository<Product> Product { get; }
		IGenericRepository<Store> Store { get; }
		Task Save();
	}
}

