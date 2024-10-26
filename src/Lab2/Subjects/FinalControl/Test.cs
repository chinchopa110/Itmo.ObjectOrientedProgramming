using Itmo.ObjectOrientedProgramming.Lab2.Labs;
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

    public SubjectBuildResult Validation(Subject subject)
    {
        int totalLabsPoints = 0;
        foreach (LabWork lab in subject.Labs) totalLabsPoints += lab.Points;

        if (totalLabsPoints != 100) return new SubjectBuildResult.Failure(new TotalPoints());

        return new SubjectBuildResult.Success(subject);
    }
}