namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Decorator.Logging;

public class Logger : ILogger
{
    public void Log(string logMessage)
    {
        Console.WriteLine(logMessage);
    }
}