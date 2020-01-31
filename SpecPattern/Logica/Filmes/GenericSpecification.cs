﻿using System;
using System.Linq.Expressions;

namespace Logica.Filmes
{
    public class GenericSpecification<T>
    {
        public GenericSpecification(Expression<Func<T, bool>> expression)
        {
            Expression = expression;
        }

        public Expression<Func<T, bool>> Expression { get; }

        public bool IsSatisfiedBy(T entity)
        {
            return Expression.Compile().Invoke(entity);
        }
    }   
}
