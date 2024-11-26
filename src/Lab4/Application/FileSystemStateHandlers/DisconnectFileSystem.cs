using Itmo.ObjectOrientedProgramming.Lab4.Application.State;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Composite;
using Itmo.ObjectOrientedProgramming.Lab4.OutputWriter;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.FileSystemStateHandlers;

public class DisconnectFileSystem : IFileSystem
{
    public FileSystemState State => FileSystemState.Disconnect;

    public FileSystemInteractionResult GoToDirectory(string path)
    {
        return new FileSystemInteractionResult.Failure(new NotConnectError());
    }

    public IFileSystemComponent List(int depth)
    {
        Func<IReadOnlyCollection<IFileSystemComponent>> emptyFactory = () => Array.Empty<IFileSystemComponent>();

        return new DirectoryComponent(" ", emptyFactory);
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

    public FileSystemInteractionResult IsValidDirectoryPath(string path)
    {
        if (!Directory.Exists(path))
            return new FileSystemInteractionResult.Failure(new NotFoundPath());

        return new FileSystemInteractionResult.Success();
    }

    public FileSystemInteractionResult IsValidFilePath(string path)
    {
        return new FileSystemInteractionResult.Failure(new NotConnectError());
    }

    public FileSystemInteractionResult CheckCollisions(string filePath)
    {
        return new FileSystemInteractionResult.Failure(new NotConnectError());
    }
}