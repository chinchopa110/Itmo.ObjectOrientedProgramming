using Itmo.ObjectOrientedProgramming.Lab3.Processing.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Processing.Errors;

public class MessageNotFound : IError
{
    public string ErrorDescription { get; }

    public MessageNotFound()
    {
        ErrorDescription = "This message not found!";
    }
}