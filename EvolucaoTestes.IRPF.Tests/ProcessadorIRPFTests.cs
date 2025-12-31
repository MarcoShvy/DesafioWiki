using Xunit;
using Moq;
using EvolucaoTestes.IRPF;
using System.Collections.Generic;

namespace EvolucaoTestes.IRPF.Tests;

public class ProcessadorIRPFTests
{
    [Fact]
    public void Executar_ComUmContribuinte_DeveExibirResultado()
    {

        var mockConsole = new Mock<IConsole>();
        var calculadora = new CalculadoraIRPF();
        var validador = new Validador();

        var entradas = new Queue<string>(new[]
        {
            "1",
            "Pedro Silva",
            "5000"
        });

        mockConsole
            .Setup(c => c.ReadLine())
            .Returns(() => entradas.Dequeue());

        var processador = new ProcessadorIRPF(
            calculadora,
            validador,
            mockConsole.Object
        );

        
        processador.Executar();

        
        mockConsole.Verify(c =>
            c.WriteLine(It.Is<string>(s => s.Contains("Pedro Silva"))),
            Times.Once);

        mockConsole.Verify(c =>
            c.WriteLine(It.Is<string>(s => s.Contains("4.494,36"))),
            Times.Once);
    }
}

