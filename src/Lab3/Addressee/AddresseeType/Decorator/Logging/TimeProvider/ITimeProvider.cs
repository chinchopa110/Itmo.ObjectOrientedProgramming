namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Decorator.Logging.TimeProvider;

public interface ITimeProvider
{
    DateTime Now { get; }
}