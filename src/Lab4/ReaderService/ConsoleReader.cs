using Itmo.ObjectOrientedProgramming.Lab4.Application.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.OutputWriter;
using Itmo.ObjectOrientedProgramming.Lab4.ParameterParser;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.ReaderService;

public class ConsoleReader : IReader
{
    private readonly IParameterParser _parameterParser;
    private readonly IFileSystemContext _fileSystemContext;
    private readonly IWriter _errorWriter;

    public ConsoleReader(IFileSystemContext fileSystemContext, IParameterParser parameterParser, IWriter errorWriter)
    {
        _fileSystemContext = fileSystemContext;
        _parameterParser = parameterParser;
        _errorWriter = errorWriter;
    }

    public void Read(IEnumerable<string> args)
    {
        using IEnumerator<string> request = args.GetEnumerator();
        ICommand? command;

        while (request.MoveNext())
        {
            command = _parameterParser.Handle(request);

            if (command == null)
            {
                _errorWriter.WriteLine("Invalid command!");
                return;
            }

            CommandExecuteResult result = command.Execute(_fileSystemContext);
            if (result is CommandExecuteResult.Failure failure)
            {
                _errorWriter.WriteLine(failure.Err.ErrorDescription);
            }
        }
    }
}