using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CompanyManager.Contracts;

public interface IRepositoryBase<T> where T : class
{
    IQueryable<T> FindAll(bool trackChanges);

    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges);

    ValueTask<EntityEntry<T>> Create(T entity);

    Task AddRange(IEnumerable<T> array);

    void Update(T entity);

    void Delete(T entity);
}