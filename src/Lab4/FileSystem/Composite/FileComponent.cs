using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Composite;

public class FileComponent : IFileSystemComponent
{
    public FileComponent(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void Accept(IComponentVisitor visitor)
    {
        visitor.Visit(this);
    }
}