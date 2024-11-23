using Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.ConnectionHandler;
using Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.FileInteractionHandler;
using Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.TreeMovementHandler;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.Factory;

public class ParameterParserFactory
{
    public static IParameterParser CreateParameterHandlerChain()
    {
        return new LocalConnectCommandParser()
            .AddNext(new DisconnectCommandParser())
            .AddNext(new TreeCommandParser())
                .AddNext(new GoToCommandParser()
                .AddNext(new ListCommandParser()))
            .AddNext(new FileCommandParser())
                .AddNext(new FileShowCommandParser())
                .AddNext(new FileDeleteCommandParser())
                .AddNext(new FileMoveCommandParser())
                .AddNext(new FileRenameCommandParser())
                .AddNext(new FileShowCommandParser());
    }
}