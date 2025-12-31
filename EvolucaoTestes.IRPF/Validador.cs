namespace EvolucaoTestes.IRPF;

public class Validador
{
    public bool ValidarNome(string nome)
    {
        return !string.IsNullOrWhiteSpace(nome) && nome.Length >= 3;
    }

    public bool ValidarSalario(string texto, out decimal salario)
    {
        salario = 0;

        if (!decimal.TryParse(texto, out salario))
            return false;

        return salario > 0;
    }

    public bool ValidarNumeroContribuintes(string texto, out int numero)
    {
        numero = 0;

        if (!int.TryParse(texto, out numero))
            return false;

        return numero > 0 && numero <= 100;
    }
}
