using System.Linq.Expressions;
using DesignPatterns.Domain;

namespace DesignPatterns.Behavioral.Specification;

public sealed class OrSpecification<T>(Specification<T> left, Specification<T> right) : Specification<T>
    where T : Entity
{
    public override Expression<Func<T, bool>> ToExpression()
    {
        var leftExpression = left.ToExpression();
        var rightExpression = right.ToExpression();
        var invokedExpression = Expression.Invoke(rightExpression, leftExpression.Parameters);

        return (Expression<Func<T, bool>>)Expression.Lambda(Expression.OrElse(leftExpression.Body, invokedExpression), leftExpression.Parameters);
    }
}
