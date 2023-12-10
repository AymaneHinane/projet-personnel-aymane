using System;
using Microsoft.EntityFrameworkCore;
using test.DB;

namespace test.Repository
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {

        protected readonly DBContext _context;
        public  GenericRepository(DBContext context) => _context = context;

        public async Task<TEntity> Add(TEntity entity)
        {
            if(_context != null)
            {
             await _context.Set<TEntity>().AddAsync(entity);
             await _context.SaveChangesAsync();
             //return entity;
            }

            return entity;
            
        }


        public async Task<List<TEntity>> GetAll()
        {
           if(_context !=null)
            {
                var data=await _context.Set<TEntity>().ToListAsync();

                if (data != null)
                    return data;              
            }

            return null;
        }


        public async Task<TEntity> Get(int id)
        {
            if(_context != null)
            {
                //var data = await _context.Set<TEntity>().SingleOrDefaultAsync(d=>d.Id==id);
                var data = await _context.Set<TEntity>().FindAsync(id);
                //var data = await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(e=>e.Id==id);

                if (data != null)
                    return data;

            }

            return null;

        }


        public async Task<TEntity> Delete(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);

            if (entity == null)
                return entity;

            
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
                      
        }



    }
}

