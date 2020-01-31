using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Filmes
{
    internal sealed class AndSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _leftSpec;
        private readonly Specification<T> _rightSpec;

        public AndSpecification(Specification<T> leftSpec, Specification<T> rightSpec)
        {
            _leftSpec = leftSpec;
            _rightSpec = rightSpec;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var leftExp = _leftSpec.ToExpression();
            var rightExp = _rightSpec.ToExpression();

            var andExp = Expression.AndAlso(leftExp.Body, rightExp.Body);
            return Expression.Lambda<Func<T, bool>>(andExp, leftExp.Parameters.Single());
        }
    }
}
