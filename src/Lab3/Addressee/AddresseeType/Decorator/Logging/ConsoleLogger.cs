using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Decorator.Logging;

public class ConsoleLogger : ILogger
{
    public void Log(Message message)
    {
        DateTime timeToLog = DateTime.Now;
        Console.WriteLine(StringToLogMessage(message, timeToLog));
    }

    private static string StringToLogMessage(Message message, DateTime timeToLog)
    {
        return $"[{timeToLog:yyyy-MM-dd HH:mm}] Upd new message:n" +
               $"Header: {message.Header}n" +
               $"Text: {message.Text}n";
    }
}