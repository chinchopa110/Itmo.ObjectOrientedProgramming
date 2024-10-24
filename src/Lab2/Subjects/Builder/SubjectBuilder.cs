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
    private int _parentId;

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

    public SubjectBuilder SetSubject(Subject existingSubject, int id)
    {
        _name = existingSubject.Name;
        _id = id;

        _labs.Clear();
        foreach (LabWork lab in existingSubject.Labs) _labs.Add(lab);

        _lectures.Clear();
        foreach (Lecture lecture in existingSubject.Lectures) _lectures.Add(lecture);

        _author = existingSubject.Author;
        _verification = existingSubject.Verification;
        _parentId = existingSubject.Id;

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
            _verification ?? throw new ArgumentNullException(nameof(_verification)),
            _parentId);

        return new SubjectBuildResult.Success(subject);
    }
}