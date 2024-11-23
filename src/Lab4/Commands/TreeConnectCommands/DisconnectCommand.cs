using Itmo.ObjectOrientedProgramming.Lab4.Application.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeConnectCommands;

public class DisconnectCommand : ICommand
{
    public CommandExecuteResult Execute(IFileSystemContext context)
    {
        context.Disconnect();

        return new CommandExecuteResult.Success();
    }
}