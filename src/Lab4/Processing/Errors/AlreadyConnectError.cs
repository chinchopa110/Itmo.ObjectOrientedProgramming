using Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors;

public class AlreadyConnectError : IError
{
    public string ErrorDescription { get; }

    public AlreadyConnectError()
    {
        ErrorDescription = "You already have a connection.";
    }
}