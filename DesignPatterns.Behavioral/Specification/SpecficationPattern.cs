using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DesignPatterns.Domain;

namespace DesignPatterns.Behavioral.Specification;


/// <summary>
/// The purpose of this pattern is to avoid domain knowledge duplication.
/// The basic idea is when you have some piece of domain knowledge, you can encapsulate this knowledge in a single unit specification, and you can reuse it in different parts of your code base.
/// 
/// <list type="bullet">
/// <listheader>
/// <term>Main use cases</term>
/// </listheader>
/// <item>
/// <term>In-memory validation</term>
/// <description>Used for validation <see cref="IEnumerable"/> collections.</description>
/// </item>
/// <item>
/// <term>Retrieving data from the database</term>
/// <description>Used for filtering <see cref="IQueryable"/> data</description>
/// </item>
/// <item>
/// <term>
/// Construction-to-order</term>
/// <description></description>
/// </item>
/// </list>
/// </summary>
public abstract class Specification<T>
    where T : class
{
    public bool IsSatisfiedBy(T entity)
    {
        Func<T, bool> predicate = this.ToExpression().Compile();
        return predicate(entity);
    }

    public abstract Expression<Func<T, bool>> ToExpression();
}

public sealed class MoviesLongerThan120Specification : Specification<Movie>
{
    public override Expression<Func<Movie, bool>> ToExpression()
    {
        var duration = 120;
        return _ => _.Duration > duration;
    }
}

public sealed class DirectorsOlderThan30Specification : Specification<Director>
{
    public override Expression<Func<Director, bool>> ToExpression()
    {
        var age = 30;
        Expression<Func<Director, bool>> ex = _ => _.Age > age;
        return ex;
    }
}