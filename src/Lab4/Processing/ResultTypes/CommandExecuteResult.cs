using Itmo.ObjectOrientedProgramming.Lab4.Processing.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Processing.ResultTypes;

public record CommandExecuteResult
{
    private CommandExecuteResult() { }

    public sealed record Success : CommandExecuteResult;

    public sealed record Failure(IError Err) : CommandExecuteResult;
}