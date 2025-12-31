namespace EvolucaoTestes.IRPF;

public class SystemConsole : IConsole
{
    public string ReadLine() => Console.ReadLine();
    public void Write(string message) => Console.Write(message);
    public void WriteLine(string message) => Console.WriteLine(message);
}
