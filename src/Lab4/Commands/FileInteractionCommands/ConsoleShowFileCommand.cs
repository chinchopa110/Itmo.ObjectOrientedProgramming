using Itmo.ObjectOrientedProgramming.Lab4.Application.Context;
using Itmo.ObjectOrientedProgramming.Lab4.OutputWriter;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileInteractionCommands;

public class ConsoleShowFileCommand : ICommand
{
    private readonly string _path;
    private readonly ConsoleWriter _consoleWriter;

    public ConsoleShowFileCommand(string path)
    {
        _path = path;
        _consoleWriter = new ConsoleWriter();
    }

    public CommandExecuteResult Execute(IFileSystemContext context)
    {
        string fullPath = GetAbsolutePath(_path, context.FileSystem.CurrentDirectory);

        if (!File.Exists(fullPath))
        {
            return new CommandExecuteResult.Failure(new NotFoundPath());
        }

        context.FileSystem.ShowFile(fullPath, _consoleWriter);
        return new CommandExecuteResult.Success();
    }

    private string GetAbsolutePath(string path, string currentDirectory)
    {
        string absolutePath = Path.IsPathRooted(path) ? path : Path.Combine(currentDirectory, path);
        return Path.GetFullPath(absolutePath);
    }
}