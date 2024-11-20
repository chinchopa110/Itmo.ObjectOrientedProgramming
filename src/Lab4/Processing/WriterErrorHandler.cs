using Itmo.ObjectOrientedProgramming.Lab4.OutputWriter;
using Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Processing;

public class WriterErrorHandler : IErrorHandler
{
    private readonly IWriter _writer;

    public WriterErrorHandler(IWriter writer)
    {
        _writer = writer;
    }

    public void ProcessError(IError err)
    {
        _writer.WriteLine(err.ErrorDescription);
    }
}