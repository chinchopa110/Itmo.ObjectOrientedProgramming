using Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Decorator;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Decorator.Logging;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using NSubstitute;
using Xunit;

namespace Lab3.Tests;

public class LoggingTest
{
    [Fact]
    public void SendMessage_ShouldLog_WhenMessageIsSent()
    {
        // Arrange
        IAddressee addresseeMock = Substitute.For<IAddressee>();
        ILogger loggerMock = Substitute.For<ILogger>();
        var loggingDecorator = new LoggingMessageDecorator(addresseeMock, loggerMock);
        var message = new Message("Test Header", "Test Text", 1);

        // Act
        loggingDecorator.DeliverMessage(message);

        // Assert
        loggerMock.Received(1).Log(message);
        addresseeMock.Received(1).DeliverMessage(message);
    }
}