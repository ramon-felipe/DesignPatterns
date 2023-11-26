using CSharpFunctionalExtensions;

namespace DesignPatterns.Infrastructure;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Maybe<TEntity> Get(int id);
    IEnumerable<TEntity> GetAll();
}
