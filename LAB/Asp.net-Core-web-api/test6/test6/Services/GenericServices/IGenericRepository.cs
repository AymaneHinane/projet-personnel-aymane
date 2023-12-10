using System;
using System.Linq.Expressions;
using test6.Models;
using X.PagedList;

namespace test6.Repository.GenericRepository
{
	public interface IGenericRepository<T> where T:class
	{

		Task<IEnumerable<T>> GetAll(
			    Expression<Func<T, bool>>? expression = null,
				Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
				List<string>? includes = null
			);

		Task<IPagedList<T>> GetPagedList(List<string>? includes = null, RequestParams? requestParams = null);

		Task<T> Get(
			Expression<Func<T, bool>>? expression = null,
			List<string>? includes = null
			);

		Task Insert(T entity);
		Task InsertRange(IEnumerable<T> entities);
		Task Delete(int id);
		void DeleteRange(params object[] entities);
		void update(T entity);

	}
}

