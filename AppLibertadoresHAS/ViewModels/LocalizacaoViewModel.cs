using AppLibertadoresHAS.Models;
using AppLibertadoresHAS.Services;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Devices.Sensors;
using Microsoft.Maui.Storage;
using System.Collections.ObjectModel;

namespace AppLibertadoresHAS.ViewModels
{
    public class LocalizacaoViewModel : BaseViewModel
    {
        public ObservableCollection<Pin> Pins { get; } = new();

        public async Task<Location> CarregarLocalizacoesAsync()
        {
            int usuarioId = Preferences.Get("UsuarioId", 0);
            string token = Preferences.Get("UsuarioToken", string.Empty);
            if (usuarioId <= 0 || string.IsNullOrWhiteSpace(token))
            {
                throw new InvalidOperationException("Entre com seu usuário para abrir o mapa.");
            }

            var pedido = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
            Location localizacao = await Geolocation.Default.GetLocationAsync(pedido)
                ?? throw new InvalidOperationException("Ative a localização do Android e tente novamente.");

            var servico = new UsuarioService(token);
            await servico.PutAtualizarLocalizacaoAsync(new Usuario
            {
                Id = usuarioId,
                Latitude = localizacao.Latitude,
                Longitude = localizacao.Longitude
            });

            var usuarios = await servico.GetUsuariosAsync();
            Pins.Clear();

            foreach (Usuario usuario in usuarios)
            {
                if (usuario.Latitude is double latitude && usuario.Longitude is double longitude)
                {
                    Pins.Add(new Pin
                    {
                        Type = PinType.Place,
                        Label = usuario.Username,
                        Address = $"E-mail: {usuario.Email}",
                        Location = new Location(latitude, longitude)
                    });
                }
            }

            return localizacao;
        }
    }
}
