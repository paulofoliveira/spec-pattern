using System;
using System.Linq;
using System.Linq.Expressions;

namespace Logica.Filmes
{
    internal sealed class NotSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _spec;

        public NotSpecification(Specification<T> spec)
        {
            _spec = spec;
        }
        public override Expression<Func<T, bool>> ToExpression()
        {
            var exp = _spec.ToExpression();
            var notExp = Expression.Not(exp.Body);

            return Expression.Lambda<Func<T, bool>>(notExp, exp.Parameters.Single());
        }
    }
}
