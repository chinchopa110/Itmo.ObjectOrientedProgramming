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
        string fullPath = GetAbsolutePath(_path, context.FileSystem.CurrentDirectory);

        if (!File.Exists(fullPath))
        {
            return new CommandExecuteResult.Failure(new NotFoundPath());
        }

        if (CheckCollisions(fullPath))
        {
            return new CommandExecuteResult.Failure(new NameTaken());
        }

        context.FileSystem.FileRename(_path, _newName);
        return new CommandExecuteResult.Success();
    }

    private string GetAbsolutePath(string path, string currentDirectory)
    {
        string absolutePath = Path.IsPathRooted(path) ? path : Path.Combine(currentDirectory, path);
        return Path.GetFullPath(absolutePath);
    }

    private bool CheckCollisions(string filePath)
    {
        if (File.Exists(filePath))
        {
            return false;
        }

        return true;
    }
}