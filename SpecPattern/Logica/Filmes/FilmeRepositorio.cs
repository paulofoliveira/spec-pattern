using CSharpFunctionalExtensions;
using Logica.Utils;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IReadOnlyList<Filme> RecuperarLista(bool paraCriancas, double avaliacaoMinima, bool disponivelComCD)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.Query<Filme>()
                    .Where(p => (p.AvaliacaoMpaa <= AvaliacaoMpaaTipo.PG || !paraCriancas)
                    && p.Avaliacao >= avaliacaoMinima
                    && (p.DataLancamento <= DateTime.Now.AddMonths(-6) || !disponivelComCD))
                    .ToList();
            }
        }
    }
}
