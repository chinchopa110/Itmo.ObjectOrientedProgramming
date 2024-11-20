using Itmo.ObjectOrientedProgramming.Lab4.Application;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeMovementCommands;

public class ListCommand : ICommand
{
    private readonly int _depth;

    public ListCommand(int depth)
    {
        _depth = depth;
    }

    public IFileSystemService Execute(IFileSystemService service)
    {
        service.List(_depth);
        return service;
    }
}