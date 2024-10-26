using Itmo.ObjectOrientedProgramming.Lab2.Labs;
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

    public SubjectBuildResult Validation(Subject subject)
    {
        int totalLabsPoints = 0;
        foreach (LabWork lab in subject.Labs) totalLabsPoints += lab.Points;

        totalLabsPoints += Points;
        if (totalLabsPoints != 100) return new SubjectBuildResult.Failure(new TotalPoints());

        return new SubjectBuildResult.Success(subject);
    }
}