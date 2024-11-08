using Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Proxy;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.Recipients.UserRecipients;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using NSubstitute;
using Xunit;

namespace Lab3.Tests;

public class LevelFilterProxyTest
{
    [Fact]
    public void SendMessage_ShouldNotSend_WhenImportanceLevelIsTooLow()
    {
        // Arrange
        IAddressee userMock = Substitute.For<IAddressee>();
        var levelFilterProxy = new LevelFilterProxy(userMock, CheckLevel);
        var lowImportanceMessage = new Message("header", "text", 3);

        // Act
        levelFilterProxy.DeliverMessage(lowImportanceMessage);

        // Assert
        userMock.DidNotReceive().DeliverMessage(Arg.Any<Message>());
    }

    [Fact]
    public void SendMessage_ShouldSendOnce_WhenFilterDiffer()
    {
        // Arrange
        var user = new User();
        var userAddressee = new UserAddressee(user);
        var levelFilterProxy = new LevelFilterProxy(userAddressee, CheckLevel);
        var message = new Message("header", "text", 3);

        // Act
        userAddressee.DeliverMessage(message);
        levelFilterProxy.DeliverMessage(message);

        // Assert
        IReadOnlyCollection<Message> mes = user.GetMessages();
        Assert.Single(mes);
    }

    private bool CheckLevel(int level)
    {
        return level >= 5;
    }
}