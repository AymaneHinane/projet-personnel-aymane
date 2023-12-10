using System;
using System.Linq.Expressions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using test6.DB;
using test6.Models;
using X.PagedList;

namespace test6.Repository.GenericRepository
{
	public class GenericRepository<T>:IGenericRepository<T> where T:class
	{

        private readonly DBContext _context;
        protected readonly DbSet<T> _db;

		public GenericRepository(DBContext context)
		{
            this._context = context;
            _db = context.Set<T>();
		}

        public async Task Delete(int id)
        {
            var entity = await _db.FindAsync(id);

            if (entity is not null)
                _context.Remove(entity);
        }

        public void DeleteRange(params object[] entities)
        {
            _context.RemoveRange(entities);
        }

        public async Task<T> Get(Expression<Func<T, bool>>? expression = null, List<string>? includes = null)
        {
            IQueryable<T> query= _db;

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
                 
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? expression = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, List<string>? includes = null)
        {
            IQueryable<T> query = _db;

            if (expression != null)
                query = query.Where(expression);

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            if (orderBy != null)
                query = orderBy(query);


            return await query.AsNoTracking().ToListAsync();
        }


        public async Task<IPagedList<T>> GetPagedList(List<string> includes = null, RequestParams requestParams = null)
        {
            IQueryable<T> query = _db;

            

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);



            return await query.AsNoTracking().ToPagedListAsync(requestParams.PageNumber, requestParams.PageSize);
        }

        public async Task Insert(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public void update(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

   
    }
}

