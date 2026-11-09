namespace MauiAppHotel.Models;

/// <summary>Dados ilustrativos de tipos de acomodação para a atividade.</summary>
public sealed class Suite
{
    public string Nome { get; }
    public string Descricao { get; }
    public decimal PrecoDiaria { get; }
    public int CapacidadeMaxima { get; }

    public Suite(string nome, string descricao, decimal precoDiaria, int capacidadeMaxima)
    {
        Nome = nome;
        Descricao = descricao;
        PrecoDiaria = precoDiaria;
        CapacidadeMaxima = capacidadeMaxima;
    }

    public override string ToString() => Nome;
}
