using Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.Recipients.SideIntegrations.MessengerIntegration;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using NSubstitute;
using Xunit;

namespace Lab3.Tests;

public class MessengerTests
{
    [Fact]
    public void SendInMessenger_ShouldSendMessage_WhenAddresseeIsMessenger()
    {
        // Arrange
        IMessenger mockMessenger = Substitute.For<IMessenger>();
        var messengerAddressee = new MessengerAddressee(mockMessenger);
        var message = new Message("Test Header", "Test Text", 2);

        // Act
        messengerAddressee.DeliverMessage(message);

        // Assert
        mockMessenger.Received(1).SendInMessenger(message);
    }
}