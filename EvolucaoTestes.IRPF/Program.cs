namespace EvolucaoTestes.IRPF;

class Program
{
    static void Main()
    {
        var processador = new Processador(
            new Calculadora(),
            new Validador(),
            new SystemConsole()
        );

        processador.Executar();
    }
}
