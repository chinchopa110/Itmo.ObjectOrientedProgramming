using Itmo.ObjectOrientedProgramming.Lab4.Application;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileInteractionCommands;

public class RenameFileCommand : ICommand
{
    private readonly string _path;
    private readonly string _newName;

    public RenameFileCommand(string path, string newName)
    {
        _path = path;
        _newName = newName;
    }

    public IFileSystemService Execute(IFileSystemService service)
    {
        service.FileRename(_path, _newName);
        return service;
    }
}