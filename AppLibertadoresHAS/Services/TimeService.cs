using AppLibertadoresHAS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppLibertadoresHAS.Services
{
    public class TimeService : Request
    {
        private readonly Request _request;
        private const string _apiUrlBase = "https://apilibertadores-luiz-hzhucrffc5b2hqa2.mexicocentral-01.azurewebsites.net/Selecoes";

        public TimeService()
        {
            _request = new Request();
        }

        public async Task<ObservableCollection<Time>> GetSelecoesAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");

            ObservableCollection<Time> lista =
                await _request.GetAsync<ObservableCollection<Time>>(_apiUrlBase + urlComplementar, string.Empty);

            return lista;
        }
    }
}
