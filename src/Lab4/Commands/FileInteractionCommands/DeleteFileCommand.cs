using Itmo.ObjectOrientedProgramming.Lab4.Application;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileInteractionCommands;

public class DeleteFileCommand : ICommand
{
    private readonly string _path;

    public DeleteFileCommand(string path)
    {
        _path = path;
    }

    public IFileSystemService Execute(IFileSystemService service)
    {
        service.FileDelete(_path);
        return service;
    }
}