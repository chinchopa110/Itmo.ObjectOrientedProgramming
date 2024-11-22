using Itmo.ObjectOrientedProgramming.Lab4.Application.FileSystemStateHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Application.State;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Context;

public class ConnectContext : IFileSystemContext
{
    public IFileSystemStateHandler FileSystem { get; }

    public ConnectContext(string fileSystemPath)
    {
        FileSystem = new ConnectFileSystemStateHandler(fileSystemPath);
    }

    public FileSystemState State => FileSystemState.Connect;

    public StateMoveResult Connect(string path)
    {
        return new StateMoveResult.InvalidMode(new AlreadyConnectError());
    }

    public StateMoveResult Disconnect()
    {
        return new StateMoveResult.Success(new DisconnectFileSystemStateHandler());
    }
}