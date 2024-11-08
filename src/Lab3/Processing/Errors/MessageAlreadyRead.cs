using Itmo.ObjectOrientedProgramming.Lab3.Processing.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Processing.Errors;

public class MessageAlreadyRead : IError
{
    public string ErrorDescription { get; }

    public MessageAlreadyRead()
    {
        ErrorDescription = "This message has already been read!";
    }
}