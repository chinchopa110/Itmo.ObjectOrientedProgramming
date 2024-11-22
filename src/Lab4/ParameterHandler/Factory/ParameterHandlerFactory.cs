using Itmo.ObjectOrientedProgramming.Lab4.ParameterHandler.ConnectionHandler;
using Itmo.ObjectOrientedProgramming.Lab4.ParameterHandler.FileInteractionHandler;
using Itmo.ObjectOrientedProgramming.Lab4.ParameterHandler.TreeMovementHandler;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterHandler.Factory;

public class ParameterHandlerFactory
{
    public static IParameterHandler CreateParameterHandlerChain()
    {
        return new LocalConnectCommandHandler()
            .AddNext(new DisconnectCommandHandler())
            .AddNext(new TreeCommandHandler())
            .AddNext(new FileCommandHandler());
    }
}