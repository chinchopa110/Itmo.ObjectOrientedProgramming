namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterParser.FileInteractionHandler.FileChainFactory;

public static class FileCommandParserFactory
{
    public static IParameterParser CreateFileCommandHandlerChain()
    {
        return new FileCopyCommandParser()
            .AddNext(new FileDeleteCommandParser())
            .AddNext(new FileMoveCommandParser())
            .AddNext(new FileRenameCommandParser())
            .AddNext(new FileShowCommandParser());
    }
}