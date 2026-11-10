using AppLibertadoresHAS.Models.DTOs;
using AppLibertadoresHAS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppLibertadoresHAS.ViewModels
{
    public class TabelaViewModel : BaseViewModel
    {
        PartidaService _partidaService;
        public ObservableCollection<PartidaDTO> Partidas { get; set; }
        public TabelaViewModel()
        {
            string token = Preferences.Get("UsuarioToken", string.Empty);
            _partidaService = new PartidaService(token);

            Partidas = new ObservableCollection<PartidaDTO>();
            _ = ObterPartidas();
        }

        public async Task ObterPartidas()
        {
            try
            {
                Partidas = await _partidaService.GetPartidasDTOAsync();
                OnPropertyChanged(nameof(Partidas));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlertAsync("Ops", ex.Message, "Detalhes" + ex.InnerException, "Ok");
            }
        }

    }
}

