using Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors;

public class NameTaken : IError
{
    public string ErrorDescription { get; }

    public NameTaken()
    {
        ErrorDescription = "This name is already taken";
    }
}