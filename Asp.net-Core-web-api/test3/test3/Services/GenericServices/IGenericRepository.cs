using System;
namespace test3.Services.GenericServices
{
	public interface IGenericRepository<T> where T:class
	{
		Task<T> GetById(int id);
		Task<IEnumerable<T>> GetAll();
		Task<T> AddItem(T item);
		Task<bool> RemoveItem(int id);
	}
}

