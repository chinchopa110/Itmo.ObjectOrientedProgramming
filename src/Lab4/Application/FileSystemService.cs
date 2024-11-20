using Itmo.ObjectOrientedProgramming.Lab4.OutputWriter;
using Itmo.ObjectOrientedProgramming.Lab4.Processing;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application;

public class FileSystemService : IFileSystemService
{
    private readonly WriterErrorHandler _consoleErrorHandler;
    private FileInteractionService? _fileInteractionService;
    private FileSystemTreeService? _fileSystemTreeService;
    private string? _currentDirectory;

    public FileSystemService(IWriter errorWriter)
    {
        _consoleErrorHandler = new WriterErrorHandler(errorWriter);
    }

    public void Connect(string path)
    {
        if (_currentDirectory is not null)
        {
            _consoleErrorHandler.ProcessError(new AlreayConnectError());
            return;
        }

        if (!Directory.Exists(path))
        {
            _consoleErrorHandler.ProcessError(new NotFoundPath());
            return;
        }

        _currentDirectory = Path.GetFullPath(path);
        _fileSystemTreeService = new FileSystemTreeService(_consoleErrorHandler);
        _fileInteractionService = new FileInteractionService(_consoleErrorHandler);
    }

    public void Disconnect()
    {
        if (_currentDirectory is null)
        {
            _consoleErrorHandler.ProcessError(new NotConnectError());
            return;
        }

        _fileSystemTreeService = null;
        _fileInteractionService = null;
        _currentDirectory = null;
    }

    public void GoToDirectory(string path)
    {
        if (_fileSystemTreeService is null || _currentDirectory is null)
        {
            _consoleErrorHandler.ProcessError(new NotConnectError());
            return;
        }

        _currentDirectory = _fileSystemTreeService.GoTo(GetAbsolutePath(path), _currentDirectory);
    }

    public void List(int depth)
    {
        if (_fileSystemTreeService is null || _currentDirectory is null)
        {
            _consoleErrorHandler.ProcessError(new NotConnectError());
            return;
        }

        _fileSystemTreeService.List(depth, _currentDirectory);
    }

    public void ShowFile(string path, IWriter outputWriter)
    {
        if (_fileInteractionService is null || _currentDirectory is null)
        {
            _consoleErrorHandler.ProcessError(new NotConnectError());
            return;
        }

        _fileInteractionService.DisplayFileContent(GetAbsolutePath(path), outputWriter);
    }

    public void FileMove(string sourcePath, string destinationPath)
    {
        if (_fileInteractionService is null || _currentDirectory is null)
        {
            _consoleErrorHandler.ProcessError(new NotConnectError());
            return;
        }

        _fileInteractionService.MoveFile(GetAbsolutePath(sourcePath), GetAbsolutePath(destinationPath));
    }

    public void FileCopy(string sourcePath, string destinationPath)
    {
        if (_fileInteractionService is null || _currentDirectory is null)
        {
            _consoleErrorHandler.ProcessError(new NotConnectError());
            return;
        }

        _fileInteractionService.CopyFile(GetAbsolutePath(sourcePath), GetAbsolutePath(destinationPath));
    }

    public void FileDelete(string path)
    {
        if (_fileInteractionService is null || _currentDirectory is null)
        {
            _consoleErrorHandler.ProcessError(new NotConnectError());
            return;
        }

        _fileInteractionService.DeleteFile(GetAbsolutePath(path));
    }

    public void FileRename(string path, string newName)
    {
        if (_fileInteractionService is null)
        {
            _consoleErrorHandler.ProcessError(new NotConnectError());
            return;
        }

        _fileInteractionService.RenameFile(GetAbsolutePath(path), newName);
    }

    private string GetAbsolutePath(string path)
    {
        if (_currentDirectory is null)
        {
            return path;
        }

        string absolutePath = Path.IsPathRooted(path) ? path : Path.Combine(_currentDirectory, path);
        return Path.GetFullPath(absolutePath);
    }
}