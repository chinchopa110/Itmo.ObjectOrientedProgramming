using Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.Recipients.UserRecipients;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Processing;
using Xunit;

namespace Lab3.Tests;

public class UserTests
{
    [Fact]
    public void ReceiveMessage_MustSave_WhenUnread()
    {
        // Arrange
        var message = new Message("header", "teeeext", 2);
        var user = new User();
        var userAddressee = new UserAddressee(user);

        // Act
        userAddressee.SendMessage(message);

        // Assert
        IReadOnlyCollection<UserMessage> res = user.GetMessages();
        UserMessage userMessage = res.First();
        Assert.False(userMessage.IsRead);
    }

    [Fact]
    public void ReceiveMessage_MustUpdate_WhenRead()
    {
        // Arrange
        var message = new Message("header", "teeeext", 2);
        var user = new User();
        var userAddressee = new UserAddressee(user);

        // Act
        userAddressee.SendMessage(message);
        IReadOnlyCollection<UserMessage> mess = user.GetMessages();
        UserMessage userMessage = mess.First();
        user.Read(userMessage);

        // Assert
        mess = user.GetMessages();
        userMessage = mess.First();
        Assert.True(userMessage.IsRead);
    }

    [Fact]
    public void Read_MustReturnError_WhenAlreadyRead()
    {
        // Arrange
        var message = new Message("header", "teeeext", 2);
        var user = new User();
        var userAddressee = new UserAddressee(user);

        // Act
        userAddressee.SendMessage(message);
        IReadOnlyCollection<UserMessage> mess = user.GetMessages();
        UserMessage userMessage = mess.First();
        user.Read(userMessage);

        mess = user.GetMessages();
        userMessage = mess.First();
        ReadUserMessageResult res = userMessage.Read();

        // Assert
        Assert.IsType<ReadUserMessageResult.Failure>(res);
    }
}