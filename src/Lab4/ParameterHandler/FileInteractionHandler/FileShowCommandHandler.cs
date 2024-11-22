using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileInteractionCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterHandler.FileInteractionHandler;

public class FileShowCommandHandler : ParameterHandlerBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current != "show")
            return Next?.Handle(request);

        if (!request.MoveNext())
            return null;

        string path = request.Current;

        if (!request.MoveNext())
            return null;

        ICommand? command = null;
        if (request.Current == "-m")
        {
            if (!request.MoveNext())
                return null;

            command = request.Current switch
            {
                "console" => new ConsoleShowFileCommand(path),
                _ => null,
            };
        }

        return command ?? Next?.Handle(request);
    }
}