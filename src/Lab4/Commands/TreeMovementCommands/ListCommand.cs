using Itmo.ObjectOrientedProgramming.Lab4.Application.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeMovementCommands;

public class ListCommand : ICommand
{
    private readonly int _depth;

    public ListCommand(int depth)
    {
        _depth = depth;
    }

    public CommandExecuteResult Execute(IFileSystemContext context)
    {
        if (context.FileSystem.List(_depth) is FileSystemInteractionResult.Failure failure)
        {
            return new CommandExecuteResult.Failure(failure.Err);
        }

        return new CommandExecuteResult.Success();
    }
}