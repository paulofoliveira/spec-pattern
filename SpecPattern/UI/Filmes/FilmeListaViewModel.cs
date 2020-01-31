﻿using System;
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
        public Command<long> ComprarTicketAdultoCommand { get; }
        public Command<long> ComprarTicketCriancaCommand { get; }
        public Command<long> ComprarTicketCDCommand { get; }
        public IReadOnlyList<Filme> Filmes { get; private set; }
        public bool ParaCriancas { get; set; }
        public double AvaliacaoMinima { get; set; }
        public bool DisponivelComCD { get; set; }

        public FilmeListaViewModel()
        {
            _repositorio = new FilmeRepositorio();

            PesquisarCommand = new Command(Pesquisar);
            ComprarTicketAdultoCommand = new Command<long>(ComprarAdultoTicket);
            ComprarTicketCriancaCommand = new Command<long>(ComprarCriancaTicket);
            ComprarTicketCDCommand = new Command<long>(ComprarCDTicket);
        }

        private void ComprarCDTicket(long filmeId)
        {
            var filmeOuNada = _repositorio.RecuperarPorId(filmeId);

            if (filmeOuNada.HasNoValue)
                return;

            var filme = filmeOuNada.Value;

            //var specification = new GenericSpecification<Filme>(Filme.TemVersaoEmCD);

            var spec = new DisponivelComCDSpecification();

            if (!spec.IsSatisfiedBy(filme))
            {
                MessageBox.Show("O filme não tem uma versão em CD", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("Você adquiriu um ticket!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ComprarCriancaTicket(long filmeId)
        {
            var filmeOuNada = _repositorio.RecuperarPorId(filmeId);

            if (filmeOuNada.HasNoValue)
                return;

            var filme = filmeOuNada.Value;

            //var permitidoParaCriancasSpec = Filme.PermitidoParaCriancas.Compile();
            //var specification = new GenericSpecification<Filme>(Filme.PermitidoParaCriancas);

            var spec = new FilmeParaCriancasSpecification();

            if (!spec.IsSatisfiedBy(filme))
            {
                MessageBox.Show("O filme não é permitido para crianças", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("Você adquiriu um ticket!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ComprarAdultoTicket(long filmeId)
        {
            MessageBox.Show("Você adquiriu um ticket!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Pesquisar()
        {
            var spec = Specification<Filme>.All;

            if (ParaCriancas)
                spec = spec.And(new FilmeParaCriancasSpecification());

            if (DisponivelComCD)
                spec = spec.And(new DisponivelComCDSpecification());

            Filmes = _repositorio.RecuperarLista(spec);
            Notify(nameof(Filmes));
        }
    }
}
