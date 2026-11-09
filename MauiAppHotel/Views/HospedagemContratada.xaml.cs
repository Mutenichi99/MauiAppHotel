using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class HospedagemContratada : ContentPage
{
    public HospedagemContratada(Reserva reserva)
    {
        InitializeComponent();

        // BindingContext leva os dados da primeira tela à tela de resultado.
        BindingContext = reserva;
    }

    private async void AoRecomecar(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}
