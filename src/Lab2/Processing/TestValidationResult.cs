using Itmo.ObjectOrientedProgramming.Lab2.Processing.Errors.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects.FinalControl;

namespace Itmo.ObjectOrientedProgramming.Lab2.Processing;

public record TestValidationResult
{
    private TestValidationResult() { }

    public sealed record Success(Test Test) : TestValidationResult;

    public sealed record Failure(IError Err) : TestValidationResult;
}