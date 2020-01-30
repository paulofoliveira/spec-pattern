using System.Collections.Generic;
using System.Windows;
using Logica.Filmes;
using UI.Common;

namespace UI.Filmes
{
    public class FilmeListaViewModel : ViewModel
    {
        private readonly FilmeRepositorio _repositorio;

        public Command PesquisarCommand { get; }
        public Command<long> ComprarTicketCommand { get; }
        public IReadOnlyList<Filme> Filmes { get; private set; }
        
        public FilmeListaViewModel()
        {
            _repositorio = new FilmeRepositorio();

            PesquisarCommand = new Command(Pesquisar);
            ComprarTicketCommand = new Command<long>(ComprarTicket);
        }

        private void ComprarTicket(long filmeId)
        {
            MessageBox.Show("Você adquiriu um ticket!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Pesquisar()
        {
            Filmes = _repositorio.RecuperarLista();
            Notify(nameof(Filmes));
        }
    }
}
