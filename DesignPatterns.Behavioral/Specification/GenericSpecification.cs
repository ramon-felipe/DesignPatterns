using DesignPatterns.Domain;
using System.Linq.Expressions;

namespace DesignPatterns.Behavioral.Specification;

public class GenericSpecification<T>(Expression<Func<T, bool>> expression)
    where T : Entity
{
    public Expression<Func<T, bool>> Expression { get => expression; }

    public bool IsSatisfiedBy(T entity)
    {
        return expression.Compile().Invoke(entity);
    }
}