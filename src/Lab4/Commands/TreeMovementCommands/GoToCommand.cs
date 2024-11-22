using Itmo.ObjectOrientedProgramming.Lab4.Application.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeMovementCommands;

public class GoToCommand : ICommand
{
    private readonly string _path;

    public GoToCommand(string path)
    {
        _path = path;
    }

    public CommandExecuteResult Execute(IFileSystemContext context)
    {
        string fullPath = GetAbsolutePath(_path, context.FileSystem.CurrentDirectory);

        if (!Directory.Exists(fullPath))
        {
            return new CommandExecuteResult.Failure(new NotFoundPath());
        }

        context.FileSystem.GoToDirectory(_path);
        return new CommandExecuteResult.Success();
    }

    private string GetAbsolutePath(string path, string currentDirectory)
    {
        string absolutePath = Path.IsPathRooted(path) ? path : Path.Combine(currentDirectory, path);
        return Path.GetFullPath(absolutePath);
    }
}