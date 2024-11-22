using Itmo.ObjectOrientedProgramming.Lab4.OutputWriter;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.FileSystemStateHandlers;

public interface IFileSystemStateHandler
{
    public string CurrentDirectory { get; }

    FileSystemInteractionResult GoToDirectory(string path);

    FileSystemInteractionResult List(int depth);

    FileSystemInteractionResult ShowFile(string path, IWriter outputWriter);

    FileSystemInteractionResult FileMove(string sourcePath, string destinationPath);

    FileSystemInteractionResult FileCopy(string sourcePath, string destinationPath);

    FileSystemInteractionResult FileDelete(string path);

    FileSystemInteractionResult FileRename(string path, string newName);
}