namespace EvolucaoTestes.IRPF;

public class Processador
{
    private readonly Calculadora _calculadora;
    private readonly Validador _validador;
    private readonly IConsole _console;

    public Processador(
        Calculadora calculadora,
        Validador validador,
        IConsole console)
    {
        _calculadora = calculadora;
        _validador = validador;
        _console = console;
    }

    public void Executar()
    {
        int quantidade = ObterNumeroContribuintes();

        for (int i = 0; i < quantidade; i++)
        {
            ProcessarContribuinte();
        }
    }

    private int ObterNumeroContribuintes()
    {
        while (true)
        {
            _console.Write("Informe o número de contribuintes a calcular: ");
            var entrada = _console.ReadLine();

            if (_validador.ValidarNumeroContribuintes(entrada, out int numero))
                return numero;

            _console.WriteLine("Por favor informe um valor válido para o número de contribuintes.");
        }
    }

    private void ProcessarContribuinte()
    {
        string nome = ObterNome();
        decimal salario = ObterSalario();

        decimal desconto = _calculadora.CalcularDesconto(salario) + _calculadora.CalcularINSS(salario);
        decimal salarioLiquido = salario - desconto;

        _console.WriteLine($"Nome do Contribuinte: {nome}");
        _console.WriteLine($"Salário Bruto: {salario:C2}");
        _console.WriteLine($"Desconto: {desconto:C2}");
        _console.WriteLine($"Salário Liquido: {salarioLiquido:C2}");
    }

    private string ObterNome()
    {
        while (true)
        {
            _console.Write("Informe o nome do contribuinte: ");
            var nome = _console.ReadLine();

            if (_validador.ValidarNome(nome))
                return nome;

            _console.WriteLine("Por favor, informe um valor válido para o contribuinte.");
        }
    }

    private decimal ObterSalario()
    {
        while (true)
        {
            _console.Write("Informe um valor válido para o salário: ");
            var entrada = _console.ReadLine();

            if (_validador.ValidarSalario(entrada, out decimal salario))
                return salario;

            _console.WriteLine("Por favor informe um valor válido para o salário.");
        }
    }
}
