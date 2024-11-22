using Itmo.ObjectOrientedProgramming.Lab4.Application.State;
using Itmo.ObjectOrientedProgramming.Lab4.OutputWriter;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.FileSystemStateHandlers;

public class DisconnectFileSystemStateHandler : IFileSystemStateHandler
{
    public string CurrentDirectory { get; }

    public DisconnectFileSystemStateHandler()
    {
        CurrentDirectory = string.Empty;
    }

    public FileSystemState State => FileSystemState.Disconnect;

    public StateMoveResult Connect(string path)
    {
        return new StateMoveResult.Success(new ConnectFileSystemStateHandler(path));
    }

    public StateMoveResult Disconnect()
    {
        return new StateMoveResult.InvalidMode(new NotConnectError());
    }

    public FileSystemInteractionResult GoToDirectory(string path)
    {
        return new FileSystemInteractionResult.Failure(new NotConnectError());
    }

    public FileSystemInteractionResult List(int depth)
    {
        return new FileSystemInteractionResult.Failure(new NotConnectError());
    }

    public FileSystemInteractionResult ShowFile(string path, IWriter outputWriter)
    {
        return new FileSystemInteractionResult.Failure(new NotConnectError());
    }

    public FileSystemInteractionResult FileMove(string sourcePath, string destinationPath)
    {
        return new FileSystemInteractionResult.Failure(new NotConnectError());
    }

    public FileSystemInteractionResult FileCopy(string sourcePath, string destinationPath)
    {
        return new FileSystemInteractionResult.Failure(new NotConnectError());
    }

    public FileSystemInteractionResult FileDelete(string path)
    {
        return new FileSystemInteractionResult.Failure(new NotConnectError());
    }

    public FileSystemInteractionResult FileRename(string path, string newName)
    {
        return new FileSystemInteractionResult.Failure(new NotConnectError());
    }
}