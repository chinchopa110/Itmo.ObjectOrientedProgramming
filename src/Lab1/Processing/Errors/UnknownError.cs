using Itmo.ObjectOrientedProgramming.Lab1.Processing.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Processing.Errors;

public class UnknownError : IError
{
    public string Message { get; }

    public UnknownError(string message)
    {
        Message = message;
    }
}