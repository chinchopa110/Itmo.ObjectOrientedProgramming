using Itmo.ObjectOrientedProgramming.Lab4.Application.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileInteractionCommands;

public class FileMoveCommand : ICommand
{
    private readonly string _oldPath;
    private readonly string _newPath;

    public FileMoveCommand(string oldPath, string newPath)
    {
        _oldPath = oldPath;
        _newPath = newPath;
    }

    public CommandExecuteResult Execute(IFileSystemContext context)
    {
        if (context.FileSystem.IsValidePath(_oldPath) is FileSystemInteractionResult.Failure)
        {
            return new CommandExecuteResult.Failure(new NotFoundPath());
        }

        if (context.FileSystem.IsValidePath(_newPath) is FileSystemInteractionResult.Failure)
        {
            return new CommandExecuteResult.Failure(new NotFoundPath());
        }

        context.FileSystem.FileMove(_oldPath, _newPath);
        return new CommandExecuteResult.Success();
    }
}