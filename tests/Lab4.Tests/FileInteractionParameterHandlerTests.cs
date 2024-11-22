using Itmo.ObjectOrientedProgramming.Lab4.Application.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileInteractionCommands;
using Itmo.ObjectOrientedProgramming.Lab4.OutputWriter;
using Itmo.ObjectOrientedProgramming.Lab4.ParameterHandler.FileInteractionHandler;
using NSubstitute;
using Xunit;

namespace Lab4.Tests;

public class FileInteractionParameterHandlerTests
{
    [Fact]
    public void Handle_ShouldReturnFileShow_WhenInputIsFileShow()
    {
        // Arrange
        var parameterHandler = new FileShowCommandHandler();
        using IEnumerator<string> request = new List<string> { "file", "show", "лолкекчебурек", "-m", "console" }.GetEnumerator();

        IFileSystemContext fileSystemService = Substitute.For<IFileSystemContext>();

        // Act
        ICommand? command = null;
        while (request.MoveNext())
        {
            command = parameterHandler.Handle(request);
        }

        // Assert
        Assert.IsType<ConsoleShowFileCommand>(command);
        command.Execute(fileSystemService);
        fileSystemService.Received().FileSystem.ShowFile("лолкекчебурек", Arg.Any<IWriter>());
    }

    [Fact]
    public void Handle_ShouldReturnFileMove_WhenInputIsFileMove()
    {
        // Arrange
        var parameterHandler = new FileMoveCommandHandler();
        using IEnumerator<string> request = new List<string> { "file", "move", "лолкекчебурек", "кеклолкарвалол" }.GetEnumerator();

        IFileSystemContext fileSystemService = Substitute.For<IFileSystemContext>();

        // Act
        ICommand? command = null;
        while (request.MoveNext())
        {
            command = parameterHandler.Handle(request);
        }

        // Assert
        Assert.IsType<FileMoveCommand>(command);
        command.Execute(fileSystemService);
        fileSystemService.Received().FileSystem.FileMove("лолкекчебурек", "кеклолкарвалол");
    }

    [Fact]
    public void Handle_ShouldReturnFileCopy_WhenInputIsFileCopy()
    {
        // Arrange
        var parameterHandler = new FileCopyCommandHandler();
        using IEnumerator<string> request = new List<string> { "file", "copy", "лолкекчебурек", "кеклолкарвалол" }.GetEnumerator();

        IFileSystemContext fileSystemService = Substitute.For<IFileSystemContext>();

        // Act
        ICommand? command = null;
        while (request.MoveNext())
        {
            command = parameterHandler.Handle(request);
        }

        // Assert
        Assert.IsType<CopyFilePathCommand>(command);
        command.Execute(fileSystemService);
        fileSystemService.Received().FileSystem.FileCopy("лолкекчебурек", "кеклолкарвалол");
    }

    [Fact]
    public void Handle_ShouldReturnFileDelete_WhenInputIsFileDelete()
    {
        // Arrange
        var parameterHandler = new FileDeleteCommandHandler();
        using IEnumerator<string> request = new List<string> { "file", "delete", "уууууууууууу" }.GetEnumerator();

        IFileSystemContext fileSystemService = Substitute.For<IFileSystemContext>();

        // Act
        ICommand? command = null;
        while (request.MoveNext())
        {
            command = parameterHandler.Handle(request);
        }

        // Assert
        Assert.IsType<DeleteFileCommand>(command);
        command.Execute(fileSystemService);
        fileSystemService.Received().FileSystem.FileDelete("уууууууууууу");
    }

    [Fact]
    public void Handle_ShouldReturnRename_WhenInputIsRename()
    {
        // Arrange
        var parameterHandler = new FileRenameCommandHandler();
        using IEnumerator<string> request = new List<string> { "file", "rename", "антон", "тарас" }.GetEnumerator();

        IFileSystemContext fileSystemService = Substitute.For<IFileSystemContext>();

        // Act
        ICommand? command = null;
        while (request.MoveNext())
        {
            command = parameterHandler.Handle(request);
        }

        // Assert
        Assert.IsType<RenameFileCommand>(command);
        command.Execute(fileSystemService);
        fileSystemService.Received().FileSystem.FileRename("антон", "тарас");
    }
}