using Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors;

public class NotFoundPath : IError
{
    public string ErrorDescription { get; }

    public NotFoundPath()
    {
        ErrorDescription = "Your path not found";
    }
}