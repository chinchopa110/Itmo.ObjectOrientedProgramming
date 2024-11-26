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
        if (context.FileSystem.IsValidFilePath(_path) is FileSystemInteractionResult.Failure)
            return new CommandExecuteResult.Failure(new NotFoundPath());

        context.FileSystem.ShowFile(_path, _consoleWriter);
        return new CommandExecuteResult.Success();
    }
}