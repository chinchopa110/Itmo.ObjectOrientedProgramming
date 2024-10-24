using Itmo.ObjectOrientedProgramming.Lab2.Processing.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Processing.Errors;

public class NotAuthor : IError
{
    public string Message { get; }

    public NotAuthor(string message)
    {
        Message = message;
    }
}