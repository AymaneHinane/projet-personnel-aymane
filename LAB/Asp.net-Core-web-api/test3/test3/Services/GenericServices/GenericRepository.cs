using System;
using Microsoft.EntityFrameworkCore;
using test3.DB;

namespace test3.Services.GenericServices
{
	public class GenericRepository<T>:IGenericRepository<T> where T:class
	{
        protected readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context) => _context = context;


        public async Task<T> AddItem(T item)
        {
            var data = await _context.Set<T>().AddAsync(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var data =  await _context.Set<T>().ToListAsync();

            if (data.FirstOrDefault() != null)
                return data;
            else
                throw new Exception("no data found !!!");
        }

        public async Task<T> GetById(int id)
        {
            var data = await _context.Set<T>().FindAsync(id);

            if (data != null)
                return data;
            else
                throw new Exception("no data found");
        }

        public async Task<bool> RemoveItem(int id)
        {
            var data = await _context.Set<T>().FindAsync(id);

            if(data != null)
            {
               _context.Remove(data);
               await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new Exception("no data found!!");
               
            }


        }
    }
}

