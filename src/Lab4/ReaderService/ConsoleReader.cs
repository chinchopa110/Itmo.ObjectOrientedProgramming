using Itmo.ObjectOrientedProgramming.Lab4.Application.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.OutputWriter;
using Itmo.ObjectOrientedProgramming.Lab4.ParameterHandler;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.ReaderService;

public class ConsoleReader : IReader
{
    private readonly IParameterHandler _parameterHandler;
    private readonly IFileSystemContext _fileSystemContext;
    private readonly IWriter _errorWriter;

    public ConsoleReader(IFileSystemContext fileSystemContext, IParameterHandler parameterHandler, IWriter errorWriter)
    {
        _fileSystemContext = fileSystemContext;
        _parameterHandler = parameterHandler;
        _errorWriter = errorWriter;
    }

    public void Read(IEnumerable<string> args)
    {
        using IEnumerator<string> request = args.GetEnumerator();
        ICommand? command;

        while (request.MoveNext())
        {
            command = _parameterHandler.Handle(request);

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