using Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Decorator.Logging;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Decorator;

public class LoggingMessageDecorator : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly ILogger _logger;

    public LoggingMessageDecorator(IAddressee addressee, ILogger logger)
    {
        _addressee = addressee;
        _logger = logger;
    }

    public void SendMessage(Message message)
    {
        _logger.Log(StringToLogMessage(message));
        _addressee.SendMessage(message);
    }

    private static string StringToLogMessage(Message message)
    {
        DateTime currentTime = DateTime.Now;
        return $"[{currentTime:yyyy-MM-dd HH:mm}] Upd new message:\n" +
               $"Header: {message.Header}\n" +
               $"Text: {message.Text}\n";
    }
}