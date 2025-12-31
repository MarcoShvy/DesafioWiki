namespace EvolucaoTestes.IRPF;

public class Contribuinte
{
    public string Nome { get; }
    public decimal SalarioBruto { get; }
    public decimal Desconto { get; set; }
    public decimal SalarioLiquido { get; set; }

    public Contribuinte(string nome, decimal salarioBruto)
    {
        Nome = nome;
        SalarioBruto = salarioBruto;
    }
}
