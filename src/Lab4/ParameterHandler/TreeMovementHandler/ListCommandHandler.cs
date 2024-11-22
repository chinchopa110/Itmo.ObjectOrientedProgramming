using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeMovementCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterHandler.TreeMovementHandler;

public class ListCommandHandler : ParameterHandlerBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current != "tree")
            return Next?.Handle(request);

        if (!request.MoveNext() || request.Current != "list")
            return Next?.Handle(request);

        if (!request.MoveNext())
            return null;

        ICommand? command;
        if (request.Current == "-d")
        {
            if (!request.MoveNext())
                return null;

            command = int.TryParse(request.Current, out int number)
                ? new ListCommand(number)
                : null;
        }
        else
        {
            command = null;
        }

        return command ?? Next?.Handle(request);
    }
}