using Itmo.ObjectOrientedProgramming.Lab4.Application;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileInteractionCommands;

public class CopyFilePathCommand : ICommand
{
    private readonly string _copyPath;
    private readonly string _targetPath;

    public CopyFilePathCommand(string copyPath, string targetPath)
    {
        _copyPath = copyPath;
        _targetPath = targetPath;
    }

    public IFileSystemService Execute(IFileSystemService service)
    {
        service.FileCopy(_copyPath, _targetPath);
        return service;
    }
}