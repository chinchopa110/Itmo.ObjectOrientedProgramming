using Itmo.ObjectOrientedProgramming.Lab4.Application.FileSystemStateHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Application.State;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Context;

public class DisconnectContext : IFileSystemContext
{
    public IFileSystemStateHandler FileSystem { get; private set; }

    public DisconnectContext()
    {
        FileSystem = new DisconnectFileSystemStateHandler();
    }

    public FileSystemState State => FileSystemState.Connect;

    public StateMoveResult Connect(string path)
    {
        FileSystem = new ConnectFileSystemStateHandler(path);
        return new StateMoveResult.Success(FileSystem);
    }

    public StateMoveResult Disconnect()
    {
        return new StateMoveResult.InvalidMode(new NotConnectError());
    }
}