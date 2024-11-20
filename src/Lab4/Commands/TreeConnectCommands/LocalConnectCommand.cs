using Itmo.ObjectOrientedProgramming.Lab4.Application;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeConnectCommands;

public class LocalConnectCommand : ICommand
{
    private readonly string _connectionPath;

    public LocalConnectCommand(string connectionPath)
    {
        _connectionPath = connectionPath;
    }

    public IFileSystemService Execute(IFileSystemService service)
    {
        service.Connect(_connectionPath);
        return service;
    }
}