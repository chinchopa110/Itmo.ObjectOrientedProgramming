using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeConnectCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.ConnectionHandler;

public class DisconnectCommandParser : ParameterParserBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current == "disconnect")
            return new DisconnectCommand();

        return Next?.Handle(request);
    }
}