using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeConnectCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterHandler.ConnectionHandler;

public class DisconnectCommandHandler : ParameterHandlerBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "disconnect")
            return Next?.Handle(request);

        return new DisconnectCommand();
    }
}