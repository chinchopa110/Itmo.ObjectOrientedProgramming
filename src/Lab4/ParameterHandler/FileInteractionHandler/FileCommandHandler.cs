using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.ParameterHandler.FileInteractionHandler.FileChainFactory;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterHandler.FileInteractionHandler;

public class FileCommandHandler : ParameterHandlerBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current == "file")
        {
            IParameterHandler fileHandler = FileCommandHandlerFactory.CreateFileCommandHandlerChain();

            if (!request.MoveNext())
                return null;

            return fileHandler.Handle(request);
        }

        return Next?.Handle(request);
    }
}