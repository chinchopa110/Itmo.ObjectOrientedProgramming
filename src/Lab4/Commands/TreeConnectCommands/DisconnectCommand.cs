using Itmo.ObjectOrientedProgramming.Lab4.Application;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeConnectCommands;

public class DisconnectCommand : ICommand
{
    public IFileSystemService Execute(IFileSystemService service)
    {
        service.Disconnect();
        return service;
    }
}