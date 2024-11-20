using Itmo.ObjectOrientedProgramming.Lab4.Application;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.ParameterHandler;

namespace Itmo.ObjectOrientedProgramming.Lab4.ReaderService;

public class ConsoleReader : IReader
{
    private readonly IParameterHandler _parameterHandler;
    private IFileSystemService _fileSystemService;

    public ConsoleReader(IFileSystemService fileSystemService, IParameterHandler parameterHandler)
    {
        _fileSystemService = fileSystemService;
        _parameterHandler = parameterHandler;
    }

    public void Read(IEnumerable<string> args)
    {
        using IEnumerator<string> request = args.GetEnumerator();
        ICommand? command;

        while (request.MoveNext())
        {
            command = _parameterHandler.Handle(request);

            if (command != null)
            {
                _fileSystemService = command.Execute(_fileSystemService);
            }
            else
            {
                Console.Error.WriteLine("Unknown command!!");
            }
        }
    }
}