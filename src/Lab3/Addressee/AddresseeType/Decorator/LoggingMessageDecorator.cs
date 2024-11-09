using Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Decorator.Logging;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Decorator.Logging.TimeProvider;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Decorator;

public class LoggingMessageDecorator
{
    private readonly IAddressee _addressee;
    private readonly ILogger _logger;
    private readonly ITimeProvider _timeProvider;

    public LoggingMessageDecorator(IAddressee addressee, ILogger logger, ITimeProvider timeProvider)
    {
        _addressee = addressee;
        _logger = logger;
        _timeProvider = timeProvider;
    }

    public void DeliverMessage(Message message)
    {
        _logger.Log(StringToLogMessage(message));
        _addressee.DeliverMessage(message);
    }

    private string StringToLogMessage(Message message)
    {
        DateTime currentTime = _timeProvider.Now;
        return $"[{currentTime:yyyy-MM-dd HH:mm}] Upd new message:n" +
               $"Header: {message.Header}n" +
               $"Text: {message.Text}n";
    }
}
