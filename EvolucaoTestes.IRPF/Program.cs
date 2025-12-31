namespace EvolucaoTestes.IRPF;

class Program
{
    static void Main()
    {
        var processador = new ProcessadorIRPF(
            new CalculadoraIRPF(),
            new Validador(),
            new SystemConsole()
        );

        processador.Executar();
    }
}
