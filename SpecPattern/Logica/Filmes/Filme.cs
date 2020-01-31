using System;
using Logica.Utils;

namespace Logica.Filmes
{
    public class Filme : Entity
    {
        public virtual string Nome { get; }
        public virtual DateTime DataLancamento { get; }
        public virtual AvaliacaoMpaaTipo AvaliacaoMpaa { get; }
        public virtual string Genero { get; }
        public virtual double Avaliacao { get; }

        protected Filme()
        {
        }

        public virtual bool PermitidoParaCriancas() => AvaliacaoMpaa <= AvaliacaoMpaaTipo.PG;
        public virtual bool TemVersaoEmCD() => DataLancamento <= DateTime.Now.AddMonths(-6);
    }


    public enum AvaliacaoMpaaTipo
    {
        G = 1,
        PG = 2,
        PG13 = 3,
        R = 4
    }
}
