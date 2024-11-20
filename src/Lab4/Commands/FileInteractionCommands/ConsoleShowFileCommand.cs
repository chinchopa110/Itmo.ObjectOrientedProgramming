using Itmo.ObjectOrientedProgramming.Lab4.Application;
using Itmo.ObjectOrientedProgramming.Lab4.OutputWriter;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileInteractionCommands;

public class ConsoleShowFileCommand : ICommand
{
    private readonly string _path;
    private readonly ConsoleWriter _consoleWriter;

    public ConsoleShowFileCommand(string path)
    {
        _path = path;
        _consoleWriter = new ConsoleWriter();
    }

    public IFileSystemService Execute(IFileSystemService service)
    {
        service.ShowFile(_path, _consoleWriter);
        return service;
    }
}