using Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Proxy;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.Recipients.UserRecipients;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Moq;
using Xunit;

namespace Lab3.Tests;

public class LevelFilterProxyTest
{
    [Fact]
    public void SendMessage_ShouldNotSend_WhenImportanceLevelIsTooLow()
    {
        // Arrange
        var userMock = new Mock<IAddressee>();
        var levelFilterProxy = new LevelFilterProxy(userMock.Object, 5);
        var lowImportanceMessage = new Message("header", "text", 3);

        // Act
        levelFilterProxy.SendMessage(lowImportanceMessage);

        // Assert
        userMock.Verify(u => u.SendMessage(It.IsAny<Message>()), Times.Never);
    }

    [Fact]
    public void SendMessage_ShouldSendOnce_WhenFilterDiffer()
    {
        // Arrange
        var user = new User();
        var userAddressee = new UserAddressee(user);
        var levelFilterProxy = new LevelFilterProxy(new UserAddressee(user), 5);
        var message = new Message("header", "text", 3);

        // Act
        userAddressee.SendMessage(message);
        levelFilterProxy.SendMessage(message);

        // Assert
        IReadOnlyCollection<UserMessage> mes = user.GetMessages();
        Assert.Single(mes);
    }
}