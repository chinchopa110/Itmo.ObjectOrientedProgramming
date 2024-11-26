using Itmo.ObjectOrientedProgramming.Lab4.Application.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileInteractionCommands;

public class CopyFilePathCommand : ICommand
{
    private readonly string _copyPath;
    private readonly string _targetPath;

    public CopyFilePathCommand(string copyPath, string targetPath)
    {
        _copyPath = copyPath;
        _targetPath = targetPath;
    }

    public CommandExecuteResult Execute(IFileSystemContext context)
    {
        if (context.FileSystem.IsValidFilePath(_copyPath) is FileSystemInteractionResult.Failure)
            return new CommandExecuteResult.Failure(new NotFoundPath());

        if (context.FileSystem.IsValidDirectoryPath(_targetPath) is FileSystemInteractionResult.Failure)
            return new CommandExecuteResult.Failure(new NotFoundPath());

        if (context.FileSystem.CheckCollisions(_targetPath) is FileSystemInteractionResult.Failure)
            return new CommandExecuteResult.Failure(new NameAlreadyExists());

        context.FileSystem.FileCopy(_copyPath, _targetPath);
        return new CommandExecuteResult.Success();
    }
}