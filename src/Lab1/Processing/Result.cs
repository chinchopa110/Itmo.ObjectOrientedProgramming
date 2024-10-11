using Itmo.ObjectOrientedProgramming.Lab1.Processing.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Processing;

public abstract record Result
{
    private Result() { }

    public sealed record Success(TimeSpan Time) : Result;

    public sealed record Failure(IError Err) : Result;
}