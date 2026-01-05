using Xunit;

namespace EvolucaoTestes.IRPF.Tests;

public class CalculadoraTests
{
    private readonly Calculadora _calculadora = new();

    [Theory]
    [InlineData(1000, 0)]
    [InlineData(1903.99, 0)]
    public void NaoDeveDescontar_SalariosIsentos(decimal salario, decimal esperado)
    {
        var desconto = _calculadora.CalcularDescontoIRPF(salario);
        Assert.Equal(esperado, desconto);
    }

    [Theory]
    [InlineData(3000, 95.20)]
    [InlineData(5000, 505.64)]
    public void DeveCalcularDescontoCorretamente(decimal salario, decimal esperado)
    {
        var desconto = _calculadora.CalcularDescontoIRPF(salario);
        Assert.Equal(esperado, desconto, 2);
    }

    [Theory]
    [InlineData(1000, 75.00)]
    [InlineData(1518.00, 113.85)]
    public void DeveCalcularINSS_Faixa1(decimal salario, decimal esperado)
    {
        var desconto = _calculadora.CalcularINSS(salario);

        Assert.Equal(esperado, desconto, 2);
    }

    [Theory]
    [InlineData(2000, 180.00)]
    [InlineData(2793.88, 251.45)]
    public void DeveCalcularINSS_Faixa2(decimal salario, decimal esperado)
    {
        var desconto = _calculadora.CalcularINSS(salario);

        Assert.Equal(esperado, desconto, 2);
    }

    [Theory]
    [InlineData(3000, 360.00)]
    [InlineData(4190.83, 502.90)]
    public void DeveCalcularINSS_Faixa3(decimal salario, decimal esperado)
    {
        var desconto = _calculadora.CalcularINSS(salario);

        Assert.Equal(esperado, desconto, 2);
    }

    [Theory]
    [InlineData(5000, 700.00)]
    [InlineData(8157.41, 1142.04)]
    public void DeveCalcularINSS_Faixa4(decimal salario, decimal esperado)
    {
        var desconto = _calculadora.CalcularINSS(salario);

        Assert.Equal(esperado, desconto, 2);
    }

    [Fact]
    public void DeveRetornarTetoINSS_QuandoSalarioUltrapassarTeto()
    {
        var salario = 10000m;

        var desconto = _calculadora.CalcularINSS(salario);

        Assert.Equal(828.39m, desconto, 2);
    }
}
