namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterHandler.TreeMovementHandler.TreeCommandChain;

public static class TreeCommandHandlerFactory
{
    public static IParameterHandler CreateTreeCommandHandlerChain()
    {
        return new GoToCommandHandler()
            .AddNext(new ListCommandHandler());
    }
}