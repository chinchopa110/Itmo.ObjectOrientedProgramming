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

    private string _currentDirectory;

    public ConnectFileSystemStateHandler(string currentDirectory)
    {
        _currentDirectory = currentDirectory;
        _componentFactory = new FileSystemComponentFactory();
    }

    public FileSystemInteractionResult GoToDirectory(string path)
    {
        _currentDirectory = GetAbsolutePath(path);
        return new FileSystemInteractionResult.Success();
    }

    public FileSystemInteractionResult List(int depth)
    {
        IFileSystemComponent component = _componentFactory.Create(_currentDirectory, depth);

        var consoleWriter = new ConsoleWriter();
        var visitor = new Visitor(consoleWriter);
        component.Accept(visitor);

        return new FileSystemInteractionResult.Success();
    }

    public FileSystemInteractionResult ShowFile(string path, IWriter outputWriter)
    {
        outputWriter.WriteLine(File.ReadAllText(GetAbsolutePath(path)));
        return new FileSystemInteractionResult.Success();
    }

    public FileSystemInteractionResult FileMove(string sourcePath, string destinationPath)
    {
        File.Move(GetAbsolutePath(sourcePath), GetAbsolutePath(destinationPath));
        return new FileSystemInteractionResult.Success();
    }

    public FileSystemInteractionResult FileCopy(string sourcePath, string destinationPath)
    {
        File.Copy(GetAbsolutePath(sourcePath), GetAbsolutePath(destinationPath), true);
        return new FileSystemInteractionResult.Success();
    }

    public FileSystemInteractionResult FileDelete(string path)
    {
        File.Delete(GetAbsolutePath(path));
        return new FileSystemInteractionResult.Success();
    }

    public FileSystemInteractionResult FileRename(string path, string newName)
    {
        string? directory = Path.GetDirectoryName(GetAbsolutePath(path));

        if (directory == null)
        {
            return new FileSystemInteractionResult.Failure(new NotFoundPath());
        }

        string newFilePath = Path.Combine(directory, newName);

        File.Move(path, newFilePath);
        return new FileSystemInteractionResult.Success();
    }

    public FileSystemInteractionResult IsValidePath(string path)
    {
        string fullPath = GetAbsolutePath(path);

        if (!File.Exists(fullPath))
        {
            return new FileSystemInteractionResult.Failure(new NotFoundPath());
        }

        return new FileSystemInteractionResult.Success();
    }

    private string GetAbsolutePath(string path)
    {
        string absolutePath = Path.IsPathRooted(path) ? path : Path.Combine(_currentDirectory, path);
        return Path.GetFullPath(absolutePath);
    }
}