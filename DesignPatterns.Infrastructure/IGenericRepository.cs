using CSharpFunctionalExtensions;
using System.Linq.Expressions;

namespace DesignPatterns.Infrastructure;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Maybe<TEntity> Get(int id);
    IReadOnlyList<TEntity> GetAll();
    IReadOnlyList<TEntity> GetAll(Expression<Func<TEntity, bool>> expression);
}
