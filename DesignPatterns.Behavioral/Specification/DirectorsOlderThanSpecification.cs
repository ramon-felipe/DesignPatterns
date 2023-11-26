using System.Linq.Expressions;
using DesignPatterns.Domain;

namespace DesignPatterns.Behavioral.Specification;

public sealed class DirectorsOlderThanSpecification(int age) : Specification<Director>
{   
    public override Expression<Func<Director, bool>> ToExpression() => director => director.Age > age;
}
