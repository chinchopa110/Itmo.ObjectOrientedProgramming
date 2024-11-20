using Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors;

public class NotConnectError : IError
{
    public string ErrorDescription { get; }

    public NotConnectError()
    {
        ErrorDescription = "You need to connect to the any system.";
    }
}