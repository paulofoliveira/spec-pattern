using System;
using System.Linq;
using System.Linq.Expressions;

namespace Logica.Filmes
{
    internal sealed class OrSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _leftSpec;
        private readonly Specification<T> _rightSpec;

        public OrSpecification(Specification<T> leftSpec, Specification<T> rightSpec)
        {
            _leftSpec = leftSpec;
            _rightSpec = rightSpec;
        }
        public override Expression<Func<T, bool>> ToExpression()
        {
            var leftExp = _leftSpec.ToExpression();
            var rightExp = _rightSpec.ToExpression();

            var orExp = Expression.OrElse(leftExp.Body, rightExp.Body);
            return Expression.Lambda<Func<T, bool>>(orExp, leftExp.Parameters.Single());
        }
    }
}
