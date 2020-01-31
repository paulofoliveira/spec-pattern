using CSharpFunctionalExtensions;
using Logica.Utils;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Logica.Filmes
{
    public class FilmeRepositorio
    {
        public Maybe<Filme> RecuperarPorId(long id)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.Get<Filme>(id);
            }
        }

        public IReadOnlyList<Filme> RecuperarLista(GenericSpecification<Filme> specification)
        {
            //Expression<Func<Filme, bool>> exp1 = paraCriancas ? Filme.PermitidoParaCriancas : p => true;
            //Expression<Func<Filme, bool>> exp2 = disponivelComCD ? Filme.TemVersaoEmCD : p => true;
            // exp1 && exp2 não funciona =/ Para funcionar teria que fazer um Dissablemby e criar outra Expession com a junção das duas

            using (ISession session = SessionFactory.OpenSession())
            {
                //return session.Query<Filme>()
                //    .Where(p => (p.AvaliacaoMpaa <= AvaliacaoMpaaTipo.PG || !paraCriancas)
                //    && p.Avaliacao >= avaliacaoMinima
                //    && (p.DataLancamento <= DateTime.Now.AddMonths(-6) || !disponivelComCD))
                //    .ToList();

                return session.Query<Filme>()
                    .Where(specification.Expression)
                    .ToList();
            }
        }
    }
}
