using Itmo.ObjectOrientedProgramming.Lab2.Processing.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Processing.Errors;

public class TotalPoints : IError
{
    public string Message { get; }

    public TotalPoints(string message)
    {
        Message = message;
    }
}