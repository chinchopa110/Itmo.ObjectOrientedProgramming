using Itmo.ObjectOrientedProgramming.Lab2.Processing.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Processing;

public record UpdateResult
{
    private UpdateResult() { }

    public sealed record Success : UpdateResult;

    public sealed record Failure(IError Err) : UpdateResult;
}