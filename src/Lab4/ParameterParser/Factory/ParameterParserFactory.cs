using Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.ConnectionHandler;
using Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.ConnectionHandler.FlagParser;
using Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.FileInteractionHandler;
using Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.FileInteractionHandler.FlagParser;
using Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.TreeMovementHandler;
using Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.TreeMovementHandler.FlagParser;

namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.Factory;

public class ParameterParserFactory
{
    public static IParameterParser CreateParameterHandlerChain()
    {
        return new LocalConnectCommandParser(new ConnectModeFlagParser<LocalConnectCommandBuilder>())
            .AddNext(new DisconnectCommandParser())
            .AddNext(new TreeCommandParser())
            .AddNext(new GoToCommandParser()
                .AddNext(new ListCommandParser(new ListParameterParser<ListCommandBuilder>())))
            .AddNext(new FileCommandParser())
            .AddNext(new FileShowCommandParser(new ShowModeFlagParser<ConsoleFileShowCommandBuilder>()))
            .AddNext(new FileCopyCommandParser())
            .AddNext(new FileDeleteCommandParser())
            .AddNext(new FileMoveCommandParser())
            .AddNext(new FileRenameCommandParser());
    }
}