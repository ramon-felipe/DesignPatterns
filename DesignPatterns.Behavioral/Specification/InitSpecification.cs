using DesignPatterns.Domain;
using System.Linq.Expressions;

namespace DesignPatterns.Behavioral.Specification;

public sealed class InitSpecification<T> : Specification<T>
    where T : Entity
{
    public override Expression<Func<T, bool>> ToExpression()
    {
        return _ => true;
    }
}