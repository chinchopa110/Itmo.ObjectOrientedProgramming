using Itmo.ObjectOrientedProgramming.Lab2.Processing;
using Itmo.ObjectOrientedProgramming.Lab2.Processing.Errors;
using Itmo.ObjectOrientedProgramming.Lab2.Prototype;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Labs;

public class LabWork : IPrototype<LabWork>, IEducationalObject
{
    public string Name { get; private set; }

    public int Id { get; }

    public int Points { get; }

    public string Description { get; private set; }

    public string Criteria { get; private set; }

    public int ParentId { get; }

    public SingleUser Author { get; }

    public LabWork(
        int labId,
        string name,
        int balls,
        string description,
        string criteria,
        SingleUser author,
        int parentId = 0)
    {
        Name = name;
        Id = labId;
        Points = balls;
        Author = author;
        Description = description;
        Criteria = criteria;
        ParentId = parentId;
    }

    public UpdateResult UpdateName(SingleUser user, string newName)
    {
        if (user.Id != Author.Id) return new UpdateResult.Failure(new NotAuthor());
        Name = newName;
        return new UpdateResult.Success();
    }

    public UpdateResult UpdateDescription(SingleUser user, string newDescription)
    {
        if (user.Id != Author.Id) return new UpdateResult.Failure(new NotAuthor());
        Description = newDescription;
        return new UpdateResult.Success();
    }

    public UpdateResult UpdateCriteria(SingleUser user, string criteria)
    {
        if (user.Id != Author.Id) return new UpdateResult.Failure(new NotAuthor());
        Criteria = criteria;
        return new UpdateResult.Success();
    }

    public LabWork Inherit(int newId)
    {
        return new LabWork(newId, Name, Points, Description, Criteria, Author, Id);
    }
}