using System;
namespace test2.Services
{
	public interface IGenericRepository<T>where T : class
	{
		Task add(T entity);
		Task addRange(IEnumerable<T> entities);

		Task<T> GetById(int id);
		Task<IEnumerable<T>> GetAll();

		Task remove(int id);

	}
}

