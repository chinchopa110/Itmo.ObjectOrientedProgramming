using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeMovementCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterHandler;

public class TreeMovementParameterHandler : ParameterHandlerBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "tree")
            return Next?.Handle(request);

        if (!request.MoveNext())
            return null;

        ICommand? command;
        switch (request.Current)
        {
            case "goto":
                if (!request.MoveNext())
                    return null;
                command = new GoToCommand(request.Current);
                break;

            case "list":
                if (!request.MoveNext())
                    return null;
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

                break;
            default:
                return null;
        }

        return command ?? Next?.Handle(request);
    }
}