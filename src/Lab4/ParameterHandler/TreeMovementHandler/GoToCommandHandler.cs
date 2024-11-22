using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeMovementCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterHandler.TreeMovementHandler;

public class GoToCommandHandler : ParameterHandlerBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current != "goto")
            return Next?.Handle(request);

        if (!request.MoveNext())
            return null;

        return new GoToCommand(request.Current);
    }
}