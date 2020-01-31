using System;
using System.Linq.Expressions;

namespace Logica.Filmes
{
    public class FilmeParaCriancasSpecification : Specification<Filme>
    {
        public override Expression<Func<Filme, bool>> ToExpression() => p => p.AvaliacaoMpaa <= AvaliacaoMpaaTipo.PG;
    }
}
