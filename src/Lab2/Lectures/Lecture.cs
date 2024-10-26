using Itmo.ObjectOrientedProgramming.Lab2.Processing;
using Itmo.ObjectOrientedProgramming.Lab2.Processing.Errors;
using Itmo.ObjectOrientedProgramming.Lab2.Prototype;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Lectures;

public class Lecture : IPrototype<Lecture>, IEducationalObject
{
    public string Name { get; private set; }

    public int Id { get; }

    public string Description { get; private set; }

    public string Content { get; private set; }

    public int ParentId { get; }

    public SingleUser Author { get; }

    public Lecture(int id, string name, string description, string content, SingleUser author, int parentId = 0)
    {
        Id = id;
        Name = name;
        Description = description;
        Content = content;
        Author = author;
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

    public UpdateResult UpdateContent(SingleUser user, string content)
    {
        if (user.Id != Author.Id) return new UpdateResult.Failure(new NotAuthor());
        Content = content;
        return new UpdateResult.Success();
    }

    public Lecture Inherit(int newId)
    {
        return new Lecture(newId, Name, Description, Content, Author, Id);
    }
}