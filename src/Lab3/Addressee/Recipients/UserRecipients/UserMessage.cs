using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Processing;
using Itmo.ObjectOrientedProgramming.Lab3.Processing.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.Recipients.UserRecipients;

public class UserMessage
{
    public Message Message { get; }

    public bool IsRead { get; private set; }

    public UserMessage(Message message)
    {
        Message = message;
        IsRead = false;
    }

    public ReadUserMessageResult Read()
    {
        if (IsRead) return new ReadUserMessageResult.Failure(new MessageAlreadyRead());

        IsRead = true;
        return new ReadUserMessageResult.Success();
    }
}