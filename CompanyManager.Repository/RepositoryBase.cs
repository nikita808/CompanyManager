using System.Linq.Expressions;
using CompanyManager.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CompanyManager.Repository;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    private readonly DatabaseContext _databaseContext;

    protected RepositoryBase(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public IQueryable<T> FindAll(bool trackChanges) =>
        !trackChanges
            ? _databaseContext.Set<T>()
                .AsNoTracking()
            : _databaseContext.Set<T>();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges) =>
        !trackChanges
            ? _databaseContext.Set<T>()
                .Where(expression)
                .AsNoTracking()
            : _databaseContext.Set<T>()
                .Where(expression);

    public ValueTask<EntityEntry<T>> CreateAsync(T entity) => _databaseContext.Set<T>().AddAsync(entity);

    public Task AddRange(IEnumerable<T> array) => _databaseContext.Set<T>().AddRangeAsync(array);

    public void Update(T entity) => _databaseContext.Set<T>().Update(entity);

    public void Delete(T entity) => _databaseContext.Set<T>().Remove(entity);
}