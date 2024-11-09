using Itmo.ObjectOrientedProgramming.Lab3.Addressee.AddresseeType;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.Recipients.SideIntegrations.MessengerIntegration;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.Recipients.SideIntegrations.MessengerIntegration.ConsoleProvaider;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using NSubstitute;
using Xunit;

namespace Lab3.Tests;

public class MessengerTests
{
    [Fact]
    public void DeliverMessage_ShouldWriteCorrectMessage_WhenCalled()
    {
        // Arrange
        IConsoleWriter consoleWriterMock = Substitute.For<IConsoleWriter>();
        var messenger = new Messenger(consoleWriterMock);
        var messengerAddressee = new MessengerAddressee(messenger);
        var message = new Message("Test Header", "Test Text", 2);
        string expectedOutput = $"Messenger:\n" +
                                $"Header: {message.Header}\n" +
                                $"Text: {message.Text}\n";

        // Act
        messengerAddressee.DeliverMessage(message);

        // Assert
        consoleWriterMock.Received(1).Write(expectedOutput);
    }
}