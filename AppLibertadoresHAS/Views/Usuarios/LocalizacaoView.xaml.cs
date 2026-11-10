using AppLibertadoresHAS.ViewModels;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Maps;

namespace AppLibertadoresHAS.Views.Usuarios;

public partial class LocalizacaoView : ContentPage
{
    private readonly LocalizacaoViewModel _viewModel = new();
    private bool _carregando;

    public LocalizacaoView()
    {
        InitializeComponent();
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (_carregando)
            return;

        _carregando = true;
        try
        {
            var localizacao = await _viewModel.CarregarLocalizacoesAsync();
            mapa.IsShowingUser = true;
            mapa.MoveToRegion(MapSpan.FromCenterAndRadius(localizacao, Distance.FromKilometers(2)));
        }
        catch (PermissionException)
        {
            await DisplayAlertAsync("Localização", "Permita o acesso à localização nas configurações do app e abra a tela novamente.", "OK");
        }
        catch (FeatureNotEnabledException)
        {
            await DisplayAlertAsync("Localização", "Ative a localização do Android e abra a tela novamente.", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Erro ao carregar o mapa", ex.Message, "OK");
        }
        finally
        {
            _carregando = false;
        }
    }
}
