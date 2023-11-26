using System.Linq.Expressions;
using DesignPatterns.Domain;

namespace DesignPatterns.Behavioral.Specification;

public sealed class MoviesLongerThan120Specification : Specification<Movie>
{
    public override Expression<Func<Movie, bool>> ToExpression()
    {
        var duration = 120;
        return _ => _.Duration > duration;
    }
}
