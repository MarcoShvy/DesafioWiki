namespace EvolucaoTestes.IRPF;

public class CalculadoraIRPF
{
    public decimal CalcularDesconto(decimal salario)
    {
        if (salario <= 1903.99m) return 0m;
        if (salario <= 2826.65m) return salario * 0.075m - 142.80m;
        if (salario <= 3751.05m) return salario * 0.15m - 354.80m;
        if (salario <= 4664.68m) return salario * 0.225m - 636.13m;

        return salario * 0.275m - 869.36m;
    }
}
