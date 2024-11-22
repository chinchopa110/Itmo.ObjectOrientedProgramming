using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.ParameterHandler.TreeMovementHandler.TreeCommandChain;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterHandler.TreeMovementHandler;

public class TreeCommandHandler : ParameterHandlerBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current == "tree")
        {
            IParameterHandler treeHandler = TreeCommandHandlerFactory.CreateTreeCommandHandlerChain();

            if (!request.MoveNext())
                return null;

            return treeHandler.Handle(request);
        }

        return Next?.Handle(request);
    }
}