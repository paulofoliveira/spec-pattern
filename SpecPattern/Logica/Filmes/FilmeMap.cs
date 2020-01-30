using FluentNHibernate.Mapping;

namespace Logica.Filmes
{
    public class FilmeMap : ClassMap<Filme>
    {
        public FilmeMap()
        {
            Id(x => x.Id);

            Map(x => x.Nome);
            Map(x => x.DataLancamento);
            Map(x => x.AvaliacaoMpaa).CustomType<int>();
            Map(x => x.Genero);
            Map(x => x.Avaliacao);
        }
    }
}
