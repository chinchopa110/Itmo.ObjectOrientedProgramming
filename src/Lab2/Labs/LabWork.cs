using Itmo.ObjectOrientedProgramming.Lab2.Processing;
using Itmo.ObjectOrientedProgramming.Lab2.Processing.Errors;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Labs;

public class LabWork
{
    public string Name { get; private set; }

    public int Id { get; }

    public int Balls { get; }

    public string Description { get; private set; }

    public string Criteria { get; private set; }

    public int ParentId { get; }

    public SingleUser Author { get; }

    public LabWork(
        string name,
        int labId,
        int balls,
        string description,
        string criteria,
        SingleUser author,
        int parentId = 0)
    {
        Name = name;
        Id = labId;
        Balls = balls;
        Author = author;
        Description = description;
        Criteria = criteria;
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

    public UpdateResult UpdateDescription(SingleUser user, string newDescription)
    {
        if (user.Id == Author.Id)
        {
            Description = newDescription;
            return new UpdateResult.Success();
        }

        return new UpdateResult.Failure(new NotAuthor("you must be the author"));
    }

    public UpdateResult UpdateCriteria(SingleUser user, string criteria)
    {
        if (user.Id == Author.Id)
        {
            Criteria = criteria;
            return new UpdateResult.Success();
        }

        return new UpdateResult.Failure(new NotAuthor("you must be the author"));
    }
}