using Itmo.ObjectOrientedProgramming.Lab4.Application.FileSystemStateHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Application.State;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Context;

public interface IFileSystemContext
{
    public FileSystemState State { get; }

    public IFileSystemStateHandler FileSystem { get; }

    StateMoveResult Connect(string path);

    StateMoveResult Disconnect();
}