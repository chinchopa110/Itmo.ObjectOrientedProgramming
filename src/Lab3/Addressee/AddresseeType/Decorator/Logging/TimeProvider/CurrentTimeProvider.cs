namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Decorator.Logging.TimeProvider;

public class CurrentTimeProvider : ITimeProvider
{
    public DateTime Now => DateTime.Now;
}