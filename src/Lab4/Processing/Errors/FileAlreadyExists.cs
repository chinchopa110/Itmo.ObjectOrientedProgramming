using Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors;

public class FileAlreadyExists : IError
{
    public string ErrorDescription { get; }

    public FileAlreadyExists(string fileName)
    {
        ErrorDescription = $"File {fileName} already exists.";
    }
}