using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.TreeMovementHandler.TreeCommandChain;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.TreeMovementHandler;

public class TreeCommandParser : ParameterParserBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current == "tree")
        {
            IParameterParser treeParser = TreeCommandParserFactory.CreateTreeCommandHandlerChain();

            if (!request.MoveNext())
                return null;

            return treeParser.Handle(request);
        }

        return Next?.Handle(request);
    }
}