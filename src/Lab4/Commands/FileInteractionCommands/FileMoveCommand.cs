using Itmo.ObjectOrientedProgramming.Lab4.Application;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileInteractionCommands;

public class FileMoveCommand : ICommand
{
    private readonly string _oldPath;
    private readonly string _newPath;

    public FileMoveCommand(string oldPath, string newPath)
    {
        _oldPath = oldPath;
        _newPath = newPath;
    }

    public IFileSystemService Execute(IFileSystemService service)
    {
        service.FileMove(_oldPath, _newPath);
        return service;
    }
}