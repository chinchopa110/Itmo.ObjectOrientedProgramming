using Itmo.ObjectOrientedProgramming.Lab2.Processing.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Processing.Errors;

public class NotAuthorError : IError
{
    public string Message { get; }

    public NotAuthorError()
    {
        Message = "You must be the author";
    }
}