using Itmo.ObjectOrientedProgramming.Lab4.Application.FileSystemStateHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Context;

public interface IFileSystemContext
{
    public IFileSystem FileSystem { get; }

    void Connect(string path);

    void Disconnect();
}