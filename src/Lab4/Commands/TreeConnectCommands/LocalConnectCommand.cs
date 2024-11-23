using Itmo.ObjectOrientedProgramming.Lab4.Application.Context;
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
        context.Connect(_connectionPath);

        return new CommandExecuteResult.Success();
    }
}