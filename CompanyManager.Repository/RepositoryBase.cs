using System.Linq.Expressions;
using CompanyManager.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CompanyManager.Repository;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected readonly DatabaseContext DatabaseContext;

    protected RepositoryBase(DatabaseContext databaseContext)
    {
        DatabaseContext = databaseContext;
    }

    public IQueryable<T> FindAll(bool trackChanges) =>
        !trackChanges
            ? DatabaseContext.Set<T>()
                .AsNoTracking()
            : DatabaseContext.Set<T>();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges) =>
        !trackChanges
            ? DatabaseContext.Set<T>()
                .Where(expression)
                .AsNoTracking()
            : DatabaseContext.Set<T>()
                .Where(expression);

    public ValueTask<EntityEntry<T>> Create(T entity) => DatabaseContext.Set<T>().AddAsync(entity);

    public void Update(T entity) => DatabaseContext.Set<T>().Update(entity);

    public void Delete(T entity) => DatabaseContext.Set<T>().Remove(entity);
}