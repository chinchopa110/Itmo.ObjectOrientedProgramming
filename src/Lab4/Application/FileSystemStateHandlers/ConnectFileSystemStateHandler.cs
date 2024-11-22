using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Composite;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Factory;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Visitors;
using Itmo.ObjectOrientedProgramming.Lab4.OutputWriter;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application.FileSystemStateHandlers;

public class ConnectFileSystemStateHandler : IFileSystemStateHandler
{
    private readonly FileSystemComponentFactory _componentFactory;

    public string CurrentDirectory { get; private set; }

    public ConnectFileSystemStateHandler(string currentDirectory)
    {
        CurrentDirectory = currentDirectory;
        _componentFactory = new FileSystemComponentFactory();
    }

    public FileSystemInteractionResult GoToDirectory(string path)
    {
        CurrentDirectory = path;
        return new FileSystemInteractionResult.Success();
    }

    public FileSystemInteractionResult List(int depth)
    {
        IFileSystemComponent component = _componentFactory.Create(CurrentDirectory, depth);

        var consoleWriter = new ConsoleWriter();
        var visitor = new Visitor(consoleWriter);
        component.Accept(visitor);

        return new FileSystemInteractionResult.Success();
    }

    public FileSystemInteractionResult ShowFile(string path, IWriter outputWriter)
    {
        outputWriter.WriteLine(File.ReadAllText(path));
        return new FileSystemInteractionResult.Success();
    }

    public FileSystemInteractionResult FileMove(string sourcePath, string destinationPath)
    {
        File.Move(sourcePath, destinationPath);
        return new FileSystemInteractionResult.Success();
    }

    public FileSystemInteractionResult FileCopy(string sourcePath, string destinationPath)
    {
        File.Copy(sourcePath, destinationPath, true);
        return new FileSystemInteractionResult.Success();
    }

    public FileSystemInteractionResult FileDelete(string path)
    {
        File.Delete(path);
        return new FileSystemInteractionResult.Success();
    }

    public FileSystemInteractionResult FileRename(string path, string newName)
    {
        string? directory = Path.GetDirectoryName(path);

        if (directory == null)
        {
            return new FileSystemInteractionResult.Failure(new NotFoundPath());
        }

        string newFilePath = Path.Combine(directory, newName);

        File.Move(path, newFilePath);
        return new FileSystemInteractionResult.Success();
    }
}