using Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors;

public class NameAlreadyExists : IError
{
    public string ErrorDescription { get; }

    public NameAlreadyExists()
    {
        ErrorDescription = "This name is already exists";
    }
}