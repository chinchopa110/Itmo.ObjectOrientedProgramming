using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileInteractionCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterHandler.FileInteractionHandler;

public class FileDeleteCommandHandler : ParameterHandlerBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current != "file")
            return Next?.Handle(request);

        if (!request.MoveNext() || request.Current != "delete")
            return Next?.Handle(request);

        if (!request.MoveNext())
            return null;

        return new DeleteFileCommand(request.Current);
    }
}