namespace Itmo.ObjectOrientedProgramming.Lab4.ParameterHandler.FileInteractionHandler.FileChainFactory;

public static class FileCommandHandlerFactory
{
    public static IParameterHandler CreateFileCommandHandlerChain()
    {
        return new FileCopyCommandHandler()
            .AddNext(new FileDeleteCommandHandler())
            .AddNext(new FileMoveCommandHandler())
            .AddNext(new FileRenameCommandHandler())
            .AddNext(new FileShowCommandHandler());
    }
}