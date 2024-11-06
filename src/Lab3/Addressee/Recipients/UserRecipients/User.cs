using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Processing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.Recipients.UserRecipients;

public class User
{
    private readonly List<UserMessage> _messages;

    public User()
    {
        _messages = new List<UserMessage>();
    }

    public void ReceiveMessage(Message message)
    {
        var userMessage = new UserMessage(message);
        _messages.Add(userMessage);
    }

    public ReadUserMessageResult Read(UserMessage userMessage)
    {
        return userMessage.Read();
    }

    public IReadOnlyCollection<UserMessage> GetMessages()
    {
        return _messages;
    }
}