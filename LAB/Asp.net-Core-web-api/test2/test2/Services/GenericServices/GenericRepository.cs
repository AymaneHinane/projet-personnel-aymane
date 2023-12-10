using System;
using Microsoft.EntityFrameworkCore;
using test2.Data;

namespace test2.Services
{
	public class GenericRepository<T>: IGenericRepository<T> where T : class 
	{
        protected readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context) => _context = context;


        public async Task add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task addRange(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var data = await _context.Set<T>().ToListAsync();

                //data.Any()
                //data.Count != 0
            if (data.FirstOrDefault() != null)
            {
                return data;
            }
            else
                throw new Exception($"{typeof(T)} data not found !!!"); 
        }

        public async Task<T> GetById(int id)
        {
            var data = await _context.Set<T>().FindAsync(id);

            if (data != null)
                return data;
            else
                throw new Exception($"{typeof(T)} data not found !!!");

        }

        public async Task remove(int id)
        {
            var data = await _context.Set<T>().FindAsync(id);

            if (data != null)
            {
                _context.Remove(data);
                await _context.SaveChangesAsync();
            }
            else
                throw new Exception($"{typeof(T)} id {id} not found !!!");         

        }


    }
}

