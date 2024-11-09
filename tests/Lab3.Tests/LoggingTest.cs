using Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Decorator;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Decorator.Logging;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Decorator.Logging.TimeProvider;
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
        ITimeProvider timeProviderMock = Substitute.For<ITimeProvider>();

        var mockCurrentTime = new DateTime(2024, 11, 9, 12, 0, 0);
        timeProviderMock.Now.Returns(mockCurrentTime);

        var loggingDecorator = new LoggingMessageDecorator(addresseeMock, loggerMock, timeProviderMock);
        var message = new Message("Test Header", "Test Text", 1);

        // Act
        loggingDecorator.DeliverMessage(message);

        // Assert
        loggerMock.Received(1).Log($"[{mockCurrentTime:yyyy-MM-dd HH:mm}] Upd new message:n" +
                                   $"Header: {message.Header}n" +
                                   $"Text: {message.Text}n");
        addresseeMock.Received(1).DeliverMessage(message);
    }
}