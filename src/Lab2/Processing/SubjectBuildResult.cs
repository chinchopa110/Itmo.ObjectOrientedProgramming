using Itmo.ObjectOrientedProgramming.Lab2.Processing.Errors.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Processing;

public record SubjectBuildResult
{
    private SubjectBuildResult() { }

    public sealed record Success(Subject Subject) : SubjectBuildResult;

    public sealed record Failure(IError Err) : SubjectBuildResult;
}