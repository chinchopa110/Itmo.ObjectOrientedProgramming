using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Composite;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Factory;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Visitors;
using Itmo.ObjectOrientedProgramming.Lab4.OutputWriter;
using Itmo.ObjectOrientedProgramming.Lab4.Processing;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application;

public class FileSystemTreeService
{
    private readonly WriterErrorHandler _consoleErrorHandler;
    private readonly FileSystemComponentFactory _componentFactory;

    public FileSystemTreeService(WriterErrorHandler consoleErrorHandler)
    {
        _consoleErrorHandler = consoleErrorHandler;
        _componentFactory = new FileSystemComponentFactory();
    }

    public string GoTo(string path, string currentDirectory)
    {
        if (!Directory.Exists(path))
        {
            _consoleErrorHandler.ProcessError(new NotFoundPath());
            return currentDirectory;
        }

        currentDirectory = path;
        return currentDirectory;
    }

    public void List(int depth, string currentDirectory)
    {
        IFileSystemComponent component = _componentFactory.Create(currentDirectory, depth);
        var consoleWriter = new ConsoleWriter();
        var visitor = new Visitor(consoleWriter);
        component.Accept(visitor);
    }
}