using Itmo.ObjectOrientedProgramming.Lab1.Processing.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Processing.Errors;

public class SpeedLimitExceeded : IError
{
    public string Message { get; }

    public SpeedLimitExceeded(string message)
    {
        Message = message;
    }
}