using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.TreeMovementHandler;

public class TreeCommandParser : ParameterParserBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current == "tree")
        {
            if (!request.MoveNext())
                return null;
        }

        return Next?.Handle(request);
    }
}