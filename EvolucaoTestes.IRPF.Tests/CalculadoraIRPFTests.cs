using Xunit;

namespace EvolucaoTestes.IRPF.Tests;

public class CalculadoraIRPFTests
{
    private readonly CalculadoraIRPF _calculadora = new();

    [Theory]
    [InlineData(1000, 0)]
    [InlineData(1903.99, 0)]
    public void NaoDeveDescontar_SalariosIsentos(decimal salario, decimal esperado)
    {
        var desconto = _calculadora.CalcularDesconto(salario);
        Assert.Equal(esperado, desconto);
    }

    [Theory]
    [InlineData(3000, 95.20)]
    [InlineData(5000, 505.64)]
    public void DeveCalcularDescontoCorretamente(decimal salario, decimal esperado)
    {
        var desconto = _calculadora.CalcularDesconto(salario);
        Assert.Equal(esperado, desconto, 2);
    }
}
