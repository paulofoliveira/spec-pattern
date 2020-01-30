using CSharpFunctionalExtensions;
using Logica.Utils;
using NHibernate;
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

        public IReadOnlyList<Filme> RecuperarLista()
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                return session.Query<Filme>().ToList();
            }
        }
    }
}
