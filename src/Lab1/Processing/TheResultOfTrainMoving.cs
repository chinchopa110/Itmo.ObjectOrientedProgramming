using Itmo.ObjectOrientedProgramming.Lab1.Processing.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Processing;

public abstract record TheResultOfTrainMoving
{
    public sealed record CompleteSection(TimeSpan Time) : TheResultOfTrainMoving;

    public sealed record SomethingWrong(IError Err) : TheResultOfTrainMoving;
}