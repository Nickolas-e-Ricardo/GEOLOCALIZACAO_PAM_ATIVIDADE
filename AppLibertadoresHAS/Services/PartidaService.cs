using AppLibertadoresHAS.Models;
using AppLibertadoresHAS.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppLibertadoresHAS.Services
{
    public class PartidaService : Request
    {
        private readonly Request _request;
        private const string _apiUrlBase = "https://apilibertadores-luiz-hzhucrffc5b2hqa2.mexicocentral-01.azurewebsites.net/Partidas";

        public PartidaService()
        {
            _request = new Request();
        }

        string _token = string.Empty;

        //ctor + TAB: Atalhos para criar construtor
        public PartidaService(string token)
        {
            _token = token;
            _request = new Request();
        }

        public async Task<ObservableCollection<Partida>> GetPartidasAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");

            ObservableCollection<Partida> lista =
                await _request.GetAsync<ObservableCollection<Partida>>(_apiUrlBase + urlComplementar, _token);

            return lista;
        }

        public async Task<Partida> PostPartidaAsync(Partida j)
        {
            Partida partidaInserido = await _request.PostAsync<Partida>(_apiUrlBase, j, _token);
            return partidaInserido;
        }
        public async Task<ObservableCollection<PartidaDTO>> GetPartidasDTOAsync()
        {
            string urlComplementar = string.Format("{0}", "/ObterTabela");

            ObservableCollection<PartidaDTO> lista =
                await _request.GetAsync<ObservableCollection<PartidaDTO>>(_apiUrlBase + urlComplementar, _token);

            return lista;
        }
    }


}
