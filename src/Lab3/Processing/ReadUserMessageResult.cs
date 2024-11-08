using Itmo.ObjectOrientedProgramming.Lab3.Processing.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Processing;

public record ReadUserMessageResult
{
    public sealed record Success : ReadUserMessageResult;

    public sealed record Failure(IError Err) : ReadUserMessageResult;
}