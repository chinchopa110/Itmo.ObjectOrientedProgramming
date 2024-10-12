using Itmo.ObjectOrientedProgramming.Lab1.Processing.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Processing.Errors;

public class PowerLimitExceeded : IError
{
    public string Message { get; }

    public PowerLimitExceeded(string message)
    {
        Message = message;
    }
}