using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Composite;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Visitors;

public interface IComponentVisitor
{
    void Visit(FileComponent component);

    void Visit(DirectoryComponent component);
}