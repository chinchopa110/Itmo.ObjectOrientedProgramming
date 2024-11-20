using Itmo.ObjectOrientedProgramming.Lab4.OutputWriter;

namespace Itmo.ObjectOrientedProgramming.Lab4.Application;

public interface IFileSystemService
{
    void Connect(string path);

    public void Disconnect();

    public void GoToDirectory(string path);

    public void List(int depth);

    public void ShowFile(string path, IWriter outputWriter);

    public void FileMove(string sourcePath, string destinationPath);

    public void FileCopy(string sourcePath, string destinationPath);

    public void FileDelete(string path);

    public void FileRename(string path, string newName);
}