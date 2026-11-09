using MauiAppHotel.Views;
using Microsoft.Maui.Graphics;

namespace MauiAppHotel;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    // API recomendada no .NET MAUI 10, evitando Application.MainPage obsoleta.
    protected override Window CreateWindow(IActivationState? activationState)
    {
        var navegacao = new NavigationPage(new ContratacaoHospedagem())
        {
            BarBackgroundColor = Color.FromArgb("#11283F"),
            BarTextColor = Colors.White
        };

        return new Window(navegacao)
        {
            Title = "Hotel Prime | Simulador de hospedagem",
            Width = 540,
            Height = 840,
            MinimumWidth = 420,
            MinimumHeight = 600
        };
    }
}
