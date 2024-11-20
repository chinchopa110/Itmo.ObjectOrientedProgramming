using Itmo.ObjectOrientedProgramming.Lab4.Application;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeMovementCommands;

public class GoToCommand : ICommand
{
    private readonly string _path;

    public GoToCommand(string path)
    {
        _path = path;
    }

    public IFileSystemService Execute(IFileSystemService service)
    {
        service.GoToDirectory(_path);
        return service;
    }
}