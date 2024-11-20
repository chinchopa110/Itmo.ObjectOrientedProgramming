using Itmo.ObjectOrientedProgramming.Lab4.OutputWriter;
using Itmo.ObjectOrientedProgramming.Lab4.Processing;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application;

public class FileInteractionService
{
    private readonly WriterErrorHandler _consoleErrorHandler;

    public FileInteractionService(WriterErrorHandler consoleErrorHandler)
    {
        _consoleErrorHandler = consoleErrorHandler;
    }

    public void DisplayFileContent(string filePath, IWriter outputWriter)
    {
        if (!File.Exists(filePath))
        {
            _consoleErrorHandler.ProcessError(new NotFoundPath());
            return;
        }

        outputWriter.WriteLine(File.ReadAllText(filePath));
    }

    public void MoveFile(string sourcePath, string destinationDirectory)
    {
        if (!File.Exists(sourcePath) || !Directory.Exists(destinationDirectory))
        {
            _consoleErrorHandler.ProcessError(new NotFoundPath());
            return;
        }

        string fileName = Path.GetFileName(sourcePath);
        string destinationPath = Path.Combine(destinationDirectory, fileName);

        if (!CheckCollisions(destinationPath))
        {
            _consoleErrorHandler.ProcessError(new NameTaken());
            return;
        }

        File.Move(sourcePath, destinationPath);
    }

    public void CopyFile(string sourcePath, string destinationDirectory)
    {
        if (!File.Exists(sourcePath) || !Directory.Exists(destinationDirectory))
        {
            _consoleErrorHandler.ProcessError(new NotFoundPath());
            return;
        }

        string fileName = Path.GetFileName(sourcePath);
        string destinationPath = Path.Combine(destinationDirectory, fileName);

        if (!CheckCollisions(destinationPath))
        {
            _consoleErrorHandler.ProcessError(new NameTaken());
            return;
        }

        File.Copy(sourcePath, destinationPath, overwrite: true);
    }

    public void DeleteFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            _consoleErrorHandler.ProcessError(new NotFoundPath());
            return;
        }

        File.Delete(filePath);
    }

    public void RenameFile(string filePath, string newFileName)
    {
        if (!File.Exists(filePath))
        {
            _consoleErrorHandler.ProcessError(new NotFoundPath());
            return;
        }

        if (!CheckCollisions(newFileName))
        {
            _consoleErrorHandler.ProcessError(new NameTaken());
            return;
        }

        string? directory = Path.GetDirectoryName(filePath);
        if (directory == null)
        {
            _consoleErrorHandler.ProcessError(new NotFoundPath());
            return;
        }

        string newFilePath = Path.Combine(directory, newFileName);

        File.Move(filePath, newFilePath);
    }

    private bool CheckCollisions(string filePath)
    {
        if (File.Exists(filePath))
        {
            _consoleErrorHandler.ProcessError(new FileAlreadyExists(Path.GetFileName(filePath)));
            return false;
        }

        return true;
    }
}