using AppLibertadoresHAS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppLibertadoresHAS.Services
{
    public class EstadioService : Request
    {
        private readonly Request _request;
        private const string _apiUrlBase = "https://apilibertadores-luiz-hzhucrffc5b2hqa2.mexicocentral-01.azurewebsites.net/Estadios";

        public EstadioService()
        {
            _request = new Request();
        }

        public async Task<ObservableCollection<Estadio>> GetEstadiosAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");
            
            ObservableCollection<Estadio> lista = 
                await _request.GetAsync<ObservableCollection<Estadio>>(_apiUrlBase + urlComplementar, string.Empty);
            
            return lista;
        }
    }
}


