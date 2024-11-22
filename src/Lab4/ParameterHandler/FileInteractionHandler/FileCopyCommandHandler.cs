using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileInteractionCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterHandler.FileInteractionHandler;

public class FileCopyCommandHandler : ParameterHandlerBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current != "file")
            return Next?.Handle(request);

        if (!request.MoveNext() || request.Current != "copy")
            return Next?.Handle(request);

        if (!request.MoveNext())
            return null;

        string path = request.Current;

        if (!request.MoveNext())
            return null;

        return new CopyFilePathCommand(path, request.Current);
    }
}