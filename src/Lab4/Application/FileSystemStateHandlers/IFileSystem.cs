using Itmo.ObjectOrientedProgramming.Lab4.Application.State;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Composite;
using Itmo.ObjectOrientedProgramming.Lab4.OutputWriter;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.FileSystemStateHandlers;

public interface IFileSystem
{
    public FileSystemState State { get; }

    FileSystemInteractionResult GoToDirectory(string path);

    IFileSystemComponent List(int depth);

    FileSystemInteractionResult ShowFile(string path, IWriter outputWriter);

    FileSystemInteractionResult FileMove(string sourcePath, string destinationPath);

    FileSystemInteractionResult FileCopy(string sourcePath, string destinationPath);

    FileSystemInteractionResult FileDelete(string path);

    FileSystemInteractionResult FileRename(string path, string newName);

    FileSystemInteractionResult IsValidPath(string path);

    FileSystemInteractionResult CheckCollisions(string filePath);
}