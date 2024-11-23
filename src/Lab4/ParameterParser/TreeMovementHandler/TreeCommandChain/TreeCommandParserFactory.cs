namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.TreeMovementHandler.TreeCommandChain;

public static class TreeCommandParserFactory
{
    public static IParameterParser CreateTreeCommandHandlerChain()
    {
        return new GoToCommandParser()
            .AddNext(new ListCommandParser());
    }
}