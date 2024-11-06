using Itmo.ObjectOrientedProgramming.Lab3.Processing.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Processing.Errors;

public class MessageAlreadyRead : IError
{
    public string Message { get; }

    public MessageAlreadyRead()
    {
        Message = "This message has already been read!";
    }
}