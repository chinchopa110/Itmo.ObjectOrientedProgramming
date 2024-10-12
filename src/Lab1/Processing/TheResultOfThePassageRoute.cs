using Itmo.ObjectOrientedProgramming.Lab1.Processing.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Processing;

public abstract record TheResultOfThePassageRoute
{
    private TheResultOfThePassageRoute() { }

    public sealed record Success(TimeSpan Time) : TheResultOfThePassageRoute;

    public sealed record Failure(IError Err) : TheResultOfThePassageRoute;
}