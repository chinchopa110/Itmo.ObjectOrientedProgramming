using Itmo.ObjectOrientedProgramming.Lab4.Application.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeMovementCommands;
using Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.TreeMovementHandler;
using NSubstitute;
using Xunit;

namespace Lab4.Tests;

public class TreeMovementParameterHandlerTests
{
    [Fact]
    public void Handle_ShouldReturnGoToCommand_WhenInputIsGoTo()
    {
        // Arrange
        var parameterHandler = new GoToCommandParser();
        using IEnumerator<string> request = new List<string> { "tree", "goto", "пупупупу" }.GetEnumerator();

        IFileSystemContext fileSystemService = Substitute.For<IFileSystemContext>();

        // Act
        ICommand? command = null;
        while (request.MoveNext())
        {
            command = parameterHandler.Handle(request);
        }

        // Assert
        Assert.IsType<GoToCommand>(command);
        command.Execute(fileSystemService);
        fileSystemService.Received().FileSystem.GoToDirectory("пупупупу");
    }

    [Fact]
    public void Handle_ShouldReturnListCommand_WhenInputIsList()
    {
        // Arrange
        var parameterHandler = new ListCommandParser();
        using IEnumerator<string> request = new List<string> { "tree", "list", "-d", "228" }.GetEnumerator();

        IFileSystemContext fileSystemService = Substitute.For<IFileSystemContext>();

        // Act
        ICommand? command = null;
        while (request.MoveNext())
        {
            command = parameterHandler.Handle(request);
        }

        // Assert
        Assert.IsType<ListCommand>(command);
        command.Execute(fileSystemService);
        fileSystemService.Received().FileSystem.List(228);
    }
}