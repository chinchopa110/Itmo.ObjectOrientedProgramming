using Itmo.ObjectOrientedProgramming.Lab4.Application;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public interface ICommand
{
    IFileSystemService Execute(IFileSystemService service);
}