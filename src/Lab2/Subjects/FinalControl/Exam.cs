namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects.FinalControl;

public class Exam : IVerification
{
    public int Ball { get; }

    public Exam(int ball)
    {
        Ball = ball;
    }
}