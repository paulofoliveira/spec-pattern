using System;
using System.Linq.Expressions;

namespace Logica.Filmes
{
    internal sealed class IdentitySpecification<T> : Specification<T>
    {
        public override Expression<Func<T, bool>> ToExpression() => p => true;
    }
}
