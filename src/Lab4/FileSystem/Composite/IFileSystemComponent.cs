using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Composite;

public interface IFileSystemComponent
{
    string Name { get; }

    void Accept(IComponentVisitor visitor);
}