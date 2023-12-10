



using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Project.Contracts;
using Project.Repository;

namespace AspBookApp.Repository;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected RepositoryContext repositoryContext;

    public  RepositoryBase(RepositoryContext repositoryContext) => this.repositoryContext = repositoryContext;

    public void Create(T entity)
    {
        repositoryContext.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        repositoryContext.Set<T>().Remove(entity);
    }

    public void Update(T entity)
    {
        repositoryContext.Set<T>().Update(entity);
    }

    public IQueryable<T> FindAll(bool trackChanges) =>
        !trackChanges ? 
          repositoryContext.Set<T>().AsNoTracking() :
          repositoryContext.Set<T>();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
       !trackChanges ?
         repositoryContext.Set<T>().Where(expression).AsNoTracking():
         repositoryContext.Set<T>().Where(expression);

    public IQueryable<T> FindByConditionWithInclude(Expression<Func<T, bool>> expression, bool trackChanges, params Expression<Func<T, object>>[] includes)
    {

        IQueryable<T> query = repositoryContext.Set<T>();

        if(!trackChanges)
          query = repositoryContext.Set<T>().Where(expression).AsNoTracking();
        else
          query = repositoryContext.Set<T>().Where(expression);

       // query  = query.Where(expression);

        if(includes.Count() > 0)
        {
            foreach(var include in includes)
            {
                query = query.Include(include);
            }
        }
                  
        return query;
    }
}