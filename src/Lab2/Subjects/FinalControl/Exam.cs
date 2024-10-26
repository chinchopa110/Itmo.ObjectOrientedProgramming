using Itmo.ObjectOrientedProgramming.Lab2.Processing;
using Itmo.ObjectOrientedProgramming.Lab2.Processing.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects.FinalControl;

public class Exam : IVerification
{
    public int Points { get; }

    public Exam(int points)
    {
        Points = points;
    }

    public VerificationValidateResult Validate(int points)
    {
        points += Points;
        if (points != 100) return new VerificationValidateResult.Failure(new InvalidTotalPointError());

        return new VerificationValidateResult.Success();
    }
}