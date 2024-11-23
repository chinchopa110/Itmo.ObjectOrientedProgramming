using Itmo.ObjectOrientedProgramming.Lab4.Application.FileSystemStateHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Application.State;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Context;

public class FileSystemContext : IFileSystemContext
{
    public IFileSystemStateHandler FileSystem { get; private set; }

    public FileSystemContext()
    {
        FileSystem = new DisconnectFileSystemStateHandler();
    }

    public FileSystemState State => FileSystemState.Disconnect;

    public StateMoveResult Connect(string path)
    {
        FileSystem = new ConnectFileSystemStateHandler(path);
        return new StateMoveResult.Success(FileSystem);
    }

    public StateMoveResult Disconnect()
    {
        FileSystem = new DisconnectFileSystemStateHandler();
        return new StateMoveResult.Success(FileSystem);
    }
}