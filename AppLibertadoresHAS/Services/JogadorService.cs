using AppLibertadoresHAS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppLibertadoresHAS.Services
{
    public class JogadorService : Request
    {
        private readonly Request _request;
        private const string _apiUrlBase = "https://apilibertadores-luiz-hzhucrffc5b2hqa2.mexicocentral-01.azurewebsites.net/Jogadores";

        public JogadorService()
        {
            _request = new Request();
        }

        public async Task<ObservableCollection<Jogador>> GetJogadoresAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");

            ObservableCollection<Jogador> lista =
                await _request.GetAsync<ObservableCollection<Jogador>>(_apiUrlBase + urlComplementar, string.Empty);

            return lista;
        }

        public async Task<Jogador> GetJogadorAsync(int id)
        {
            string urlComplementar = $"/{id}";

            Jogador jogador = await _request.GetAsync<Jogador>(_apiUrlBase + urlComplementar, string.Empty);

            return jogador;
        }

        public async Task<Jogador> PostJogadorAsync(Jogador j)
        {
            int id = await _request.PostReturnIntAsync<Jogador>(_apiUrlBase, j, string.Empty);
            j.Id = id;
            return j;
        }



    }

}
