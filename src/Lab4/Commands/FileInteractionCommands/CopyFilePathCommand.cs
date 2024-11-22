using Itmo.ObjectOrientedProgramming.Lab4.Application.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.ResultTypes;

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

    public CommandExecuteResult Execute(IFileSystemContext context)
    {
        string fullCopyPath = GetAbsolutePath(_copyPath, context.FileSystem.CurrentDirectory);
        string fullTargetPath = GetAbsolutePath(_targetPath, context.FileSystem.CurrentDirectory);

        if (!File.Exists(fullCopyPath) || !File.Exists(fullTargetPath))
        {
            return new CommandExecuteResult.Failure(new NotFoundPath());
        }

        if (CheckCollisions(fullTargetPath))
        {
            return new CommandExecuteResult.Failure(new NameTaken());
        }

        context.FileSystem.FileCopy(fullCopyPath, fullTargetPath);
        return new CommandExecuteResult.Success();
    }

    private string GetAbsolutePath(string path, string currentDirectory)
    {
        string absolutePath = Path.IsPathRooted(path) ? path : Path.Combine(currentDirectory, path);
        return Path.GetFullPath(absolutePath);
    }

    private bool CheckCollisions(string filePath)
    {
        if (File.Exists(filePath))
        {
            return false;
        }

        return true;
    }
}