using Itmo.ObjectOrientedProgramming.Lab4.Application.FileSystemStateHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.Context;

public class FileSystemContext : IFileSystemContext
{
    public IFileSystem FileSystem { get; private set; }

    public FileSystemContext()
    {
        FileSystem = new DisconnectFileSystem();
    }

    public void Connect(string path)
    {
        FileSystem = new LocalFileSystem(path);
    }

    public void Disconnect()
    {
        FileSystem = new DisconnectFileSystem();
    }
}