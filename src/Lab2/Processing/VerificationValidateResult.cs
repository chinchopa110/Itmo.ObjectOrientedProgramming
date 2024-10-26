using Itmo.ObjectOrientedProgramming.Lab2.Processing.Errors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Processing;

public record VerificationValidateResult
{
    private VerificationValidateResult() { }

    public sealed record Success : VerificationValidateResult;

    public sealed record Failure(IError Err) : VerificationValidateResult;
}