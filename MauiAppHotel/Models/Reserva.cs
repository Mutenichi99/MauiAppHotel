using System.Globalization;

namespace MauiAppHotel.Models;

/// <summary>Uma simulação local: não realiza uma contratação real.</summary>
public sealed class Reserva
{
    private static readonly CultureInfo CulturaBrasil = CultureInfo.GetCultureInfo("pt-BR");

    public Suite Suite { get; }
    public int Adultos { get; }
    public int Criancas { get; }
    public DateTime Checkin { get; }
    public DateTime Checkout { get; }

    public Reserva(Suite suite, int adultos, int criancas, DateTime checkin, DateTime checkout)
    {
        Suite = suite;
        Adultos = adultos;
        Criancas = criancas;
        Checkin = checkin.Date;
        Checkout = checkout.Date;
    }

    public int Noites => (Checkout - Checkin).Days;
    public decimal ValorTotal => Noites * Suite.PrecoDiaria;
    public string NomeSuite => Suite.Nome;
    public string DescricaoSuite => Suite.Descricao;
    public string HospedesFormatado => $"{Adultos} adulto(s) e {Criancas} criança(s)";
    public string PeriodoFormatado => $"{Checkin:dd/MM/yyyy} a {Checkout:dd/MM/yyyy}";
    public string NoitesFormatado => Noites == 1 ? "1 noite" : $"{Noites} noites";
    public string DiariaFormatada => Suite.PrecoDiaria.ToString("C2", CulturaBrasil);
    public string TotalFormatado => ValorTotal.ToString("C2", CulturaBrasil);
}
