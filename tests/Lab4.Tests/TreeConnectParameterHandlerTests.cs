using Itmo.ObjectOrientedProgramming.Lab4.Application;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeConnectCommands;
using Itmo.ObjectOrientedProgramming.Lab4.ParameterHandler;
using NSubstitute;
using Xunit;

namespace Lab4.Tests;

public class TreeConnectParameterHandlerTests
{
    [Fact]
    public void Handle_ShouldReturnDisconnectCommand_WhenInputIsDisconnect()
    {
        // Arrange
        var parameterHandler = new TreeConnectParameterHandler();
        using IEnumerator<string> request = new List<string> { "disconnect" }.GetEnumerator();

        // Act
        ICommand? command = null;
        while (request.MoveNext())
        {
            command = parameterHandler.Handle(request);
        }

        // Assert
        Assert.IsType<DisconnectCommand>(command);
    }

    [Fact]
    public void Handle_ShouldReturnConnectCommand_WhenInputIsConnect()
    {
        // Arrange
        var parameterHandler = new TreeConnectParameterHandler();
        using IEnumerator<string> request = new List<string> { "connect", "парампарампам", "-m", "local" }.GetEnumerator();

        IFileSystemService fileSystemService = Substitute.For<IFileSystemService>();

        // Act
        ICommand? command = null;
        while (request.MoveNext())
        {
            command = parameterHandler.Handle(request);
        }

        // Assert
        Assert.IsType<LocalConnectCommand>(command);
        command.Execute(fileSystemService);
        fileSystemService.Received().Connect("парампарампам");
    }
}