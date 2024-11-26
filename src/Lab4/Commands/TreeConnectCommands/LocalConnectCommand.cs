using Itmo.ObjectOrientedProgramming.Lab4.Application.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeConnectCommands;

public class LocalConnectCommand : ICommand
{
    private readonly string _connectionPath;

    public LocalConnectCommand(string connectionPath)
    {
        _connectionPath = connectionPath;
    }

    public CommandExecuteResult Execute(IFileSystemContext context)
    {
        if (context.FileSystem.IsValidDirectoryPath(_connectionPath) is FileSystemInteractionResult.Failure)
            return new CommandExecuteResult.Failure(new NotFoundPath());

        context.Connect(_connectionPath);

        return new CommandExecuteResult.Success();
    }
}