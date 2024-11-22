using Itmo.ObjectOrientedProgramming.Lab4.Application.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeConnectCommands;

public class DisconnectCommand : ICommand
{
    public CommandExecuteResult Execute(IFileSystemContext context)
    {
        if (context.Disconnect() is StateMoveResult.InvalidMode failure)
        {
            return new CommandExecuteResult.Failure(failure.Err);
        }

        return new CommandExecuteResult.Success();
    }
}