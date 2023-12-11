
using System.Linq.Expressions;
using AspBookApp.Contracts.Repository;
using AspBookApp.Repository.Context;
using Microsoft.EntityFrameworkCore;


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

    //If we use the Update method from our repository, even if we change just the Age property, all properties will be updated in the database.
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


        if(includes.Count() > 0)
        {
            foreach(var include in includes)
            {
                query = query.Include(include);
            }
        }

        query  = query.Where(expression);
          
        return query;
    }
}