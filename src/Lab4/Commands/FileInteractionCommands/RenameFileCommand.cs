using Itmo.ObjectOrientedProgramming.Lab4.Application.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileInteractionCommands;

public class RenameFileCommand : ICommand
{
    private readonly string _path;
    private readonly string _newName;

    public RenameFileCommand(string path, string newName)
    {
        _path = path;
        _newName = newName;
    }

    public CommandExecuteResult Execute(IFileSystemContext context)
    {
        if (context.FileSystem.IsValidePath(_path) is FileSystemInteractionResult.Failure)
        {
            return new CommandExecuteResult.Failure(new NotFoundPath());
        }

        context.FileSystem.FileRename(_path, _newName);
        return new CommandExecuteResult.Success();
    }
}