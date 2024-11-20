using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Composite;
using Itmo.ObjectOrientedProgramming.Lab4.OutputWriter;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Visitors;

public class Visitor : IComponentVisitor
{
    private readonly string _directorySymbol;
    private readonly string _fileSymbol;
    private readonly string _indentSymbol;
    private readonly IWriter _writer;
    private int _depth;

    public Visitor(IWriter writer, string directorySymbol = "|--", string fileSymbol = "|-->", string indentSymbol = "   ")
    {
        _directorySymbol = directorySymbol;
        _fileSymbol = fileSymbol;
        _indentSymbol = indentSymbol;
        _writer = writer;
    }

    public void Visit(FileComponent component)
    {
        WriteIndented(component.Name, _fileSymbol);
    }

    public void Visit(DirectoryComponent component)
    {
        WriteIndented(component.Name, _directorySymbol);

        _depth += 1;

        foreach (IFileSystemComponent innerComponent in component.Components)
        {
            innerComponent.Accept(this);
        }

        _depth -= 1;
    }

    private void WriteIndented(string value, string symbol)
    {
        if (_depth > 0)
        {
            _writer.Write(string.Concat(Enumerable.Repeat(_indentSymbol, _depth)));
            _writer.Write(symbol + " ");
        }

        _writer.WriteLine(value);
    }
}