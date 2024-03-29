﻿using DesignPatterns.Domain;
using System.Collections;
using System.Linq.Expressions;

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
    where T : Entity
{
    public bool IsSatisfiedBy(T entity)
    {
        Func<T, bool> predicate = this.ToExpression().Compile();
        return predicate(entity);
    }

    public abstract Expression<Func<T, bool>> ToExpression();

    public Specification<T> And(Specification<T> specification)
    {       
        return new AndSpecification<T>(this, specification);
    }
    public Specification<T> Or(Specification<T> specification)
    {
        return new OrSpecification<T>(this, specification);
    }
    public Specification<T> Not() => new NotSpecification<T>(this);

    public static Specification<T> operator &(Specification<T> ls, Specification<T> rs) => ls.And(rs);
    public static Specification<T> operator |(Specification<T> ls, Specification<T> rs) => ls.Or(rs);
    public static Specification<T> operator !(Specification<T> spec) => spec.Not();
}