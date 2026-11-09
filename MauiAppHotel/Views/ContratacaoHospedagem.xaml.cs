using System.Globalization;
using MauiAppHotel.Models;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    private static readonly CultureInfo CulturaBrasil = CultureInfo.GetCultureInfo("pt-BR");

    private readonly List<Suite> _suites =
    [
        new Suite("Suíte Essencial", "Ambiente acolhedor, cama de casal e Wi-Fi.", 240m, 2),
        new Suite("Suíte Conforto", "Mais espaço, café da manhã e TV smart.", 360m, 4),
        new Suite("Suíte Premium", "Experiência superior, varanda e hidromassagem.", 520m, 6)
    ];

    public ContratacaoHospedagem()
    {
        InitializeComponent();

        // O Picker exibe objetos Suite e preserva o preço/capacidade para o cálculo.
        pck_quarto.ItemsSource = _suites;
        pck_quarto.ItemDisplayBinding = new Binding(nameof(Suite.Nome));

        // .NET 10: DatePicker.Date é DateTime? (aceita null).
        var hoje = DateTime.Today;
        dtpck_checkin.MinimumDate = hoje;
        dtpck_checkout.MinimumDate = hoje.AddDays(1);
        dtpck_checkin.Date = hoje;
        dtpck_checkout.Date = hoje.AddDays(1);
        pck_quarto.SelectedIndex = 0;

        // Atualização automática da prévia sempre que uma opção é alterada.
        pck_quarto.SelectedIndexChanged += (_, _) => AtualizarPrevia();
        stp_adultos.ValueChanged += (_, _) => AtualizarPrevia();
        stp_criancas.ValueChanged += (_, _) => AtualizarPrevia();
        dtpck_checkin.DateSelected += (_, _) => AtualizarPrevia();
        dtpck_checkout.DateSelected += (_, _) => AtualizarPrevia();

        AtualizarPrevia();
    }

    private void AtualizarPrevia()
    {
        if (pck_quarto.SelectedItem is not Suite suite)
            return;

        lbl_descricao_suite.Text = $"{suite.Descricao}  •  Até {suite.CapacidadeMaxima} hóspedes";
        lbl_preco_diaria.Text = $"{suite.PrecoDiaria.ToString("C2", CulturaBrasil)} / diária";

        DateTime? checkin = dtpck_checkin.Date;
        DateTime? checkout = dtpck_checkout.Date;
        int noites = checkin.HasValue && checkout.HasValue
            ? Math.Max(0, (checkout.Value.Date - checkin.Value.Date).Days)
            : 0;

        lbl_noites.Text = noites == 1 ? "1 noite" : $"{noites} noites";
        lbl_valor_previa.Text = (noites * suite.PrecoDiaria).ToString("C2", CulturaBrasil);
        lbl_aviso.IsVisible = false;
    }

    private async void AoAvancar(object sender, EventArgs e)
    {
        if (pck_quarto.SelectedItem is not Suite suite)
        {
            await Avisar("Escolha uma suíte para continuar.");
            return;
        }

        int adultos = (int)stp_adultos.Value;
        int criancas = (int)stp_criancas.Value;
        int hospedes = adultos + criancas;
        if (adultos < 1)
        {
            await Avisar("Selecione pelo menos um adulto.");
            return;
        }
        if (hospedes > suite.CapacidadeMaxima)
        {
            await Avisar($"A {suite.Nome} acomoda no máximo {suite.CapacidadeMaxima} hóspedes. Reduza o número de hóspedes ou escolha outra suíte.");
            return;
        }

        DateTime? checkin = dtpck_checkin.Date;
        DateTime? checkout = dtpck_checkout.Date;
        if (!checkin.HasValue || !checkout.HasValue)
        {
            await Avisar("Selecione o check-in e o check-out.");
            return;
        }
        if (checkin.Value.Date < DateTime.Today)
        {
            await Avisar("O check-in não pode estar no passado.");
            return;
        }
        if (checkout.Value.Date <= checkin.Value.Date)
        {
            await Avisar("O check-out precisa ser posterior ao check-in.");
            return;
        }

        // Calcula a hospedagem com os preços ilustrativos informados na lista.
        var reserva = new Reserva(suite, adultos, criancas, checkin.Value, checkout.Value);
        await Navigation.PushAsync(new HospedagemContratada(reserva));
    }

    private async Task Avisar(string mensagem)
    {
        lbl_aviso.Text = mensagem;
        lbl_aviso.IsVisible = true;
        await DisplayAlertAsync("Verifique os dados", mensagem, "Entendi");
    }

    private async void AoAbrirSobre(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sobre());
    }
}
