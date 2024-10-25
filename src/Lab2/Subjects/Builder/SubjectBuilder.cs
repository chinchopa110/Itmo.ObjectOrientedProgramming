using Itmo.ObjectOrientedProgramming.Lab2.Labs;
using Itmo.ObjectOrientedProgramming.Lab2.Lectures;
using Itmo.ObjectOrientedProgramming.Lab2.Processing;
using Itmo.ObjectOrientedProgramming.Lab2.Processing.Errors;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects.FinalControl;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects.Builder;

public class SubjectBuilder
{
    private readonly List<LabWork> _labs = [];
    private readonly List<Lecture> _lectures = [];
    private string? _name;
    private int _id;
    private IVerification? _verification;
    private SingleUser? _author;

    public SubjectBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public SubjectBuilder SetId(int id)
    {
        _id = id;
        return this;
    }

    public SubjectBuilder AddLab(LabWork lab)
    {
        _labs.Add(lab);
        return this;
    }

    public SubjectBuilder AddLecture(Lecture lecture)
    {
        _lectures.Add(lecture);
        return this;
    }

    public SubjectBuilder SetVerification(IVerification verification)
    {
        _verification = verification;
        return this;
    }

    public SubjectBuilder SetAuthor(SingleUser author)
    {
        _author = author;
        return this;
    }

    public SubjectBuildResult Build()
    {
        int totalPoints = _labs.Sum(lab => lab.Balls);

        if (_verification is Exam exam) totalPoints += exam.Ball;
        if (totalPoints != 100)
            return new SubjectBuildResult.Failure(new TotalPoints("The total points must be one hundred"));

        var subject = new Subject(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _id,
            _labs,
            _lectures,
            _author ?? throw new ArgumentNullException(nameof(_author)),
            _verification ?? throw new ArgumentNullException(nameof(_verification)));

        return new SubjectBuildResult.Success(subject);
    }
}