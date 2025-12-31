using Xunit;

namespace EvolucaoTestes.IRPF.Tests;

public class ValidadorTests
{
    private readonly Validador _validador = new();

    [Fact]
    public void NomeCurto_DeveSerInvalido()
    {
        Assert.False(_validador.ValidarNome("Jo"));
    }

    [Fact]
    public void SalarioNegativo_DeveSerInvalido()
    {
        Assert.False(_validador.ValidarSalario("-100", out _));
    }

    [Fact]
    public void NumeroContribuintesValido_DevePassar()
    {
        Assert.True(_validador.ValidarNumeroContribuintes("3", out _));
    }
}
