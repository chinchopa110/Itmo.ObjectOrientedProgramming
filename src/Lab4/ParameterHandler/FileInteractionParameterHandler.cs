using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileInteractionCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterHandler;

public class FileInteractionParameterHandler : ParameterHandlerBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "file")
            return Next?.Handle(request);

        if (!request.MoveNext())
            return null;

        ICommand? command;
        string path;
        switch (request.Current)
        {
            case "show":
                if (!request.MoveNext())
                    return null;

                path = request.Current;

                if (!request.MoveNext())
                    return null;
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
                else
                {
                    command = null;
                }

                break;
            case "move":
                if (!request.MoveNext())
                    return null;

                path = request.Current;

                if (!request.MoveNext())
                    return null;

                command = new FileMoveCommand(path, request.Current);
                break;
            case "copy":
                if (!request.MoveNext())
                    return null;

                path = request.Current;

                if (!request.MoveNext())
                    return null;

                command = new CopyFilePathCommand(path, request.Current);
                break;
            case "delete":
                if (!request.MoveNext())
                    return null;
                command = new DeleteFileCommand(request.Current);
                break;
            case "rename":
                if (!request.MoveNext())
                    return null;

                path = request.Current;

                if (!request.MoveNext())
                    return null;
                command = new RenameFileCommand(path, request.Current);
                break;
            default:
                return null;
        }

        return command ?? Next?.Handle(request);
    }
}