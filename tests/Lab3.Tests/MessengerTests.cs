using Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.Recipients.SideIntegrations.MessengerIntegration;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Moq;
using Xunit;

namespace Lab3.Tests;

public class MessengerTests
{
    [Fact]
    public void SendInMessenger_ShouldSendMessage_WhenAddresseeIsMessenger()
    {
        // Arrange
        var mockMessenger = new Mock<IMessenger>();
        var messengerAddressee = new MessengerAddressee(mockMessenger.Object);
        var message = new Message("Test Header", "Test Text", 2);

        // Act
        messengerAddressee.SendMessage(message);

        // Assert
        mockMessenger.Verify(m => m.SendInMessenger(message), Times.Once);
    }
}