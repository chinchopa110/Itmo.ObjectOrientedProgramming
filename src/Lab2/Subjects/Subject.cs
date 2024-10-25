using Itmo.ObjectOrientedProgramming.Lab2.Labs;
using Itmo.ObjectOrientedProgramming.Lab2.Lectures;
using Itmo.ObjectOrientedProgramming.Lab2.Processing;
using Itmo.ObjectOrientedProgramming.Lab2.Processing.Errors;
using Itmo.ObjectOrientedProgramming.Lab2.Prototype;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects.FinalControl;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects;

public class Subject : IPrototype<Subject>
{
    public string Name { get; private set; }

    public int Id { get; }

    public IEnumerable<LabWork> Labs { get; }

    public IEnumerable<Lecture> Lectures { get; private set; }

    public IVerification Verification { get; }

    public int ParentId { get; }

    public SingleUser Author { get; }

    public Subject(
        string name,
        int id,
        IEnumerable<LabWork> labs,
        IEnumerable<Lecture> lectures,
        SingleUser author,
        IVerification verification,
        int parentId = 0)
    {
        Name = name;
        Id = id;
        Labs = labs;
        Lectures = lectures;
        Author = author;
        Verification = verification;
        ParentId = parentId;
    }

    public UpdateResult UpdateName(SingleUser user, string newName)
    {
        if (user.Id == Author.Id)
        {
            Name = newName;
            return new UpdateResult.Success();
        }

        return new UpdateResult.Failure(new NotAuthor("you must be the author"));
    }

    public UpdateResult UpdateLectures(SingleUser user, IEnumerable<Lecture> lectures)
    {
        if (user.Id == Author.Id)
        {
            Lectures = lectures;
            return new UpdateResult.Success();
        }

        return new UpdateResult.Failure(new NotAuthor("you must be the author"));
    }

    public UpdateResult UpdateMinTestBall(SingleUser user, int ball)
    {
        if (user.Id != Author.Id) return new UpdateResult.Failure(new NotAuthor("you must be the author"));

        if (Verification is Test test)
        {
            if (test.UpdateMinBall(ball) is not TestValidationResult.Success)
                return new UpdateResult.Failure(new MinBallLimit("the minimum score must be no more than 100"));
            return new UpdateResult.Success();
        }

        return new UpdateResult.Failure(new ExaminationSubject("this subject is not creditable"));
    }

    public Subject Inherit(int newId)
    {
        var subject = new Subject(Name, newId, Labs, Lectures, Author, Verification, Id);

        return subject;
    }
}