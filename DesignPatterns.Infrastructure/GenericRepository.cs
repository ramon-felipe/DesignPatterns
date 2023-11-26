using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DesignPatterns.Infrastructure;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Domain.Entity
{
    protected readonly AppDbContext dbContext;
    protected readonly DbSet<TEntity> dbSet;

    public GenericRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
        this.dbSet = dbContext.Set<TEntity>();
    }

    public Maybe<TEntity> Get(int id)
    {
        var entity = this.dbSet.Find(id);

        return entity == null ? Maybe<TEntity>.None : Maybe<TEntity>.From(entity);
    }   

    public IReadOnlyList<TEntity> GetAll()
    {
        return this.dbSet.AsNoTracking().ToList();
    }

    public IReadOnlyList<TEntity> GetAll(Expression<Func<TEntity, bool>> expression)
    {
        return this.dbSet
            .AsNoTracking()
            .Where(expression)
            .ToList();
    }
}
