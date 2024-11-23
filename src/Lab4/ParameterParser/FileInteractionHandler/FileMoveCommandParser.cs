using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileInteractionCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.FileInteractionHandler;

public class FileMoveCommandParser : ParameterParserBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current != "move")
            return Next?.Handle(request);

        if (!request.MoveNext())
            return null;

        string path = request.Current;

        if (!request.MoveNext())
            return null;

        return new FileMoveCommand(path, request.Current);
    }
}
