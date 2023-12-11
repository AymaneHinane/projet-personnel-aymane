using System;
namespace test.Repository
{
	public interface IGenericRepository<T> where T:class
	{
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Delete(int id);
    }
}

