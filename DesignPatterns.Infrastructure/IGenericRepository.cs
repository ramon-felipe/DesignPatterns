using CSharpFunctionalExtensions;
using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace DesignPatterns.Infrastructure;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Maybe<TEntity> Get(int id);
    IEnumerable<TEntity> GetAll();
    IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression);
}
