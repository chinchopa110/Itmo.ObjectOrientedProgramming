using Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors;

public class AlreayConnectError : IError
{
    public string ErrorDescription { get; }

    public AlreayConnectError()
    {
        ErrorDescription = "You already have a connection.";
    }
}