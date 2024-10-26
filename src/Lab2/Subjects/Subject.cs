using Itmo.ObjectOrientedProgramming.Lab2.Labs;
using Itmo.ObjectOrientedProgramming.Lab2.Lectures;
using Itmo.ObjectOrientedProgramming.Lab2.Processing;
using Itmo.ObjectOrientedProgramming.Lab2.Processing.Errors;
using Itmo.ObjectOrientedProgramming.Lab2.Prototype;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects.FinalControl;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects;

public class Subject : IPrototype<Subject>, IEducationalObject
{
    public string Name { get; private set; }

    public int Id { get; }

    public IEnumerable<LabWork> Labs { get; }

    public IEnumerable<Lecture> Lectures { get; private set; }

    public IVerification Verification { get; private set; }

    public int ParentId { get; }

    public SingleUser Author { get; }

    public Subject(
        int id,
        string name,
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
        if (user.Id != Author.Id) return new UpdateResult.Failure(new NotAuthorError());
        Name = newName;
        return new UpdateResult.Success();
    }

    public UpdateResult UpdateLectures(SingleUser user, IEnumerable<Lecture> lectures)
    {
        if (user.Id != Author.Id) return new UpdateResult.Failure(new NotAuthorError());
        Lectures = lectures;
        return new UpdateResult.Success();
    }

    public UpdateResult UpdateMinTestPoints(SingleUser user, int points)
    {
        if (user.Id != Author.Id) return new UpdateResult.Failure(new NotAuthorError());

        TestValidationResult validationResult = Test.Create(points);

        if (validationResult is TestValidationResult.Failure)
            return new UpdateResult.Failure(new InvalidMinPointError());

        Test test = ((TestValidationResult.Success)validationResult).Test;
        Verification = test;

        return new UpdateResult.Success();
    }

    public Subject Inherit(int newId)
    {
        return new Subject(id: newId, Name, Labs, Lectures, Author, Verification, parentId: Id);
    }
}