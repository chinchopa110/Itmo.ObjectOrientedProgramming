using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeConnectCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.ConnectionHandler;

public class LocalConnectCommandParser : ParameterParserBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "connect")
            return Next?.Handle(request);

        if (!request.MoveNext())
            return null;

        string address = request.Current;

        if (!request.MoveNext())
            return null;

        ICommand? command;
        if (request.Current == "-m")
        {
            if (!request.MoveNext())
                return null;
            command = request.Current switch
            {
                "local" => new LocalConnectCommand(address),
                _ => null,
            };
        }
        else
        {
            command = null;
        }

        return command ?? Next?.Handle(request);
    }
}