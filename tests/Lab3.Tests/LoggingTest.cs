using Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Decorator;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Decorator.Logging;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Moq;
using Xunit;

namespace Lab3.Tests;

public class LoggingTest
{
    [Fact]
    public void SendMessage_ShouldLog_WhenMessageIsSent()
    {
        // Arrange
        var addresseeMock = new Mock<IAddressee>();
        var loggerMock = new Mock<ILogger>();
        var loggingDecorator = new LoggingMessageDecorator(addresseeMock.Object, loggerMock.Object);
        var message = new Message("Test Header", "Test Text", 1);

        DateTime currentTime = DateTime.Now;
        string expectedLogMessage = $"[{currentTime:yyyy-MM-dd HH:mm}] Upd new message:\n" +
                                    $"Header: {message.Header}\n" +
                                    $"Text: {message.Text}\n";

        // Act
        loggingDecorator.SendMessage(message);

        // Assert
        loggerMock.Verify(l => l.Log(expectedLogMessage), Times.Once);
        addresseeMock.Verify(u => u.SendMessage(message), Times.Once);
    }
}