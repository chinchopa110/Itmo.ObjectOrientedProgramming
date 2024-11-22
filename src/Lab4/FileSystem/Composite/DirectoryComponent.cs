using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Composite;

public class DirectoryComponent : IFileSystemComponent
{
    private readonly Lazy<IReadOnlyCollection<IFileSystemComponent>> _lazyComponents;

    public DirectoryComponent(string name, Func<IReadOnlyCollection<IFileSystemComponent>> componentsFactory)
    {
        Name = name;
        _lazyComponents = new Lazy<IReadOnlyCollection<IFileSystemComponent>>(componentsFactory);
    }

    public string Name { get; }

    public IReadOnlyCollection<IFileSystemComponent> Components => _lazyComponents.Value;

    public void Accept(IComponentVisitor visitor)
    {
        visitor.Visit(this);
    }
}
