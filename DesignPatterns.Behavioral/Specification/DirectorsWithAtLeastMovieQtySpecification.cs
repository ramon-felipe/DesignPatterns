using System.Linq.Expressions;
using DesignPatterns.Domain;

namespace DesignPatterns.Behavioral.Specification;

public sealed class DirectorsWithAtLeastMovieQtySpecification(int movieQty) : Specification<Director>
{
    public override Expression<Func<Director, bool>> ToExpression() => director => director.Movies.Count >= movieQty;
}