﻿using System.Linq.Expressions;

namespace DesignPatterns.Behavioral.Specification;

public class ParameterReplacer : ExpressionVisitor
{

    private readonly ParameterExpression _parameter;

    protected override Expression VisitParameter(ParameterExpression node)
        => base.VisitParameter(_parameter);

    internal ParameterReplacer(ParameterExpression parameter)
    {
        _parameter = parameter;
    }
}