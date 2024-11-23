using Itmo.ObjectOrientedProgramming.Lab4.Application.Context;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Composite;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Visitors;
using Itmo.ObjectOrientedProgramming.Lab4.OutputWriter;
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
        IFileSystemComponent component = context.FileSystem.List(_depth);

        var consoleWriter = new ConsoleWriter();
        var visitor = new Visitor(consoleWriter);
        component.Accept(visitor);

        return new CommandExecuteResult.Success();
    }
}