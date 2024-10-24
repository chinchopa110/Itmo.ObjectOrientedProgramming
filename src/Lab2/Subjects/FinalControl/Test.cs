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
            return new TestValidationResult.Failure(new MinBallLimit("The minimum score must be no more than 100"));

        return new TestValidationResult.Success(new Test(minBall));
    }

    public TestValidationResult UpdateMinBall(int newball)
    {
        if (newball > 100)
            return new TestValidationResult.Failure(new MinBallLimit("the minimum score must be no more than 100"));

        MinBall = newball;
        return new TestValidationResult.Success(this);
    }
}