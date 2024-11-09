namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.Recipients.SideIntegrations.MessengerIntegration.ConsoleProvaider;

public class ConsoleWriter : IConsoleWriter
{
    public void Write(string message)
    {
        Console.WriteLine(message);
    }
}