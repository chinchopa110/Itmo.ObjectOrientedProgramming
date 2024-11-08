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
        userAddressee.DeliverMessage(message);

        // Assert
        IReadOnlyCollection<Message> res = user.GetMessages();
        Message userMessage = res.First();

        Assert.False(user.IsMessageRead(userMessage));
    }

    [Fact]
    public void ReceiveMessage_MustUpdate_WhenRead()
    {
        // Arrange
        var message = new Message("header", "teeeext", 2);
        var user = new User();
        var userAddressee = new UserAddressee(user);

        // Act
        userAddressee.DeliverMessage(message);
        IReadOnlyCollection<Message> mess = user.GetMessages();
        Message userMessage = mess.First();
        user.Read(userMessage);

        // Assert
        mess = user.GetMessages();
        userMessage = mess.First();
        Assert.True(user.IsMessageRead(userMessage));
    }

    [Fact]
    public void Read_MustReturnError_WhenAlreadyRead()
    {
        // Arrange
        var message = new Message("header", "teeeext", 2);
        var user = new User();
        var userAddressee = new UserAddressee(user);

        // Act
        userAddressee.DeliverMessage(message);
        IReadOnlyCollection<Message> mess = user.GetMessages();
        Message userMessage = mess.First();
        user.Read(userMessage);

        ReadUserMessageResult res = user.Read(userMessage);

        // Assert
        Assert.IsType<ReadUserMessageResult.Failure>(res);
    }
}