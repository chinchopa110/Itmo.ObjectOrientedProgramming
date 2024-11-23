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
        string fullCopyPath = GetAbsolutePath(_oldPath, context.FileSystem.CurrentDirectory);
        string fullTargetPath = GetAbsolutePath(_newPath, context.FileSystem.CurrentDirectory);

        if (!File.Exists(fullCopyPath) || !File.Exists(fullTargetPath))
        {
            return new CommandExecuteResult.Failure(new NotFoundPath());
        }

        if (CheckCollisions(fullTargetPath))
        {
            return new CommandExecuteResult.Failure(new NameTaken());
        }

        context.FileSystem.FileMove(fullCopyPath, fullTargetPath);
        return new CommandExecuteResult.Success();
    }

    private string GetAbsolutePath(string path, string currentDirectory)
    {
        string absolutePath = Path.IsPathRooted(path) ? path : Path.Combine(currentDirectory, path);
        return Path.GetFullPath(absolutePath);
    }

    private bool CheckCollisions(string filePath)
    {
        return File.Exists(filePath);
    }
}