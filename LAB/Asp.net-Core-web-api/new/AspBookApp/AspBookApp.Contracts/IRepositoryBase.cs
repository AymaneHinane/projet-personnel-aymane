
using System.Linq.Expressions;

namespace AspBookApp.Contracts.Repository;


public interface IRepositoryBase<T>{
    IQueryable<T> FindAll(bool trackChanges);
    IQueryable<T> FindByCondition(Expression<Func<T,bool>> expression,bool trackChanges);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    IQueryable<T> FindByConditionWithInclude(Expression<Func<T,bool>> expression,bool trackChanges,params Expression<Func<T, object>>[] includes);
}