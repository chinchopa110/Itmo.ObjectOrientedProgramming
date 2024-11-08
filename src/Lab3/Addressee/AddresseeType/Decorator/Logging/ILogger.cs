using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Decorator.Logging;

public interface ILogger
{
    void Log(Message message);
}