using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Processing;
using Itmo.ObjectOrientedProgramming.Lab3.Processing.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.Recipients.UserRecipients;

public class User
{
    private readonly Dictionary<Message, bool> _messages;

    public User()
    {
        _messages = new Dictionary<Message, bool>();
    }

    public void ReceiveMessage(Message message)
    {
        _messages[message] = false;
    }

    public ReadUserMessageResult Read(Message message)
    {
        if (!_messages.ContainsKey(message))
        {
            return new ReadUserMessageResult.Failure(new MessageNotFound());
        }

        if (_messages[message])
            return new ReadUserMessageResult.Failure(new MessageAlreadyRead());

        _messages[message] = true;
        return new ReadUserMessageResult.Success();
    }

    public IReadOnlyCollection<Message> GetMessages()
    {
        return _messages.Keys.ToList();
    }

    public bool IsMessageRead(Message message)
    {
        return _messages.TryGetValue(message, out bool isRead) && isRead;
    }
}