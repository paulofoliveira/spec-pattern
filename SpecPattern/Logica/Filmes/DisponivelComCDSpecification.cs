using System;
using System.Linq.Expressions;

namespace Logica.Filmes
{
    public class DisponivelComCDSpecification : Specification<Filme>
    {
        public override Expression<Func<Filme, bool>> ToExpression() => p => p.DataLancamento <= DateTime.Now.AddMonths(-6);
    }
}
