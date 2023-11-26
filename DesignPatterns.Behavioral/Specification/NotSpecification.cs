using System.Linq.Expressions;
using DesignPatterns.Domain;

namespace DesignPatterns.Behavioral.Specification;

public sealed class NotSpecification<T>(Specification<T> expression) : Specification<T>
    where T : Entity
{
    public override Expression<Func<T, bool>> ToExpression()
    {
        var exp = expression.ToExpression();
        var notExpression = Expression.Not(exp.Body);

        return Expression.Lambda<Func<T, bool>>(notExpression, exp.Parameters.Single());
    }
}