using AppLibertadoresHAS.ViewModels;

namespace AppLibertadoresHAS.Views.Partidas;

public partial class TabelaView : ContentPage
{
    TabelaViewModel viewModel;
    public TabelaView()
	{
		InitializeComponent();

        viewModel = new TabelaViewModel();
        BindingContext = viewModel;
        Title = "Tabela";
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _ = viewModel.ObterPartidas();
    }
}

