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

    public void DeliverMessage(Message message)
    {
        _logger.Log(message);
        _addressee.DeliverMessage(message);
    }
}