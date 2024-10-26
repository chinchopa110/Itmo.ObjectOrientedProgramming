using Itmo.ObjectOrientedProgramming.Lab2.Processing;
using Itmo.ObjectOrientedProgramming.Lab2.Processing.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects.FinalControl;

public class Test : IVerification
{
    public int MinBall { get; private set; }

    private Test(int minBall)
    {
        MinBall = minBall;
    }

    public static TestValidationResult Create(int minBall)
    {
        if (minBall > 100)
            return new TestValidationResult.Failure(new InvalidMinPointError());

        return new TestValidationResult.Success(new Test(minBall));
    }

    public VerificationValidateResult Validate(int points)
    {
        if (points != 100) return new VerificationValidateResult.Failure(new InvalidTotalPointError());

        return new VerificationValidateResult.Success();
    }
}