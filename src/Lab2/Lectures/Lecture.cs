using Itmo.ObjectOrientedProgramming.Lab2.Processing;
using Itmo.ObjectOrientedProgramming.Lab2.Processing.Errors;
using Itmo.ObjectOrientedProgramming.Lab2.Prototype;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Lectures;

public class Lecture : IPrototype<Lecture>
{
    public string Name { get; private set; }

    public int Id { get; }

    public string Description { get; private set; }

    public string Content { get; private set; }

    public int ParentId { get; }

    public SingleUser Author { get; }

    public Lecture(string name, int id, string description, string content, SingleUser author, int parentId = 0)
    {
        Name = name;
        Id = id;
        Description = description;
        Content = content;
        Author = author;
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

    public UpdateResult UpdateContent(SingleUser user, string content)
    {
        if (user.Id == Author.Id)
        {
            Content = content;
            return new UpdateResult.Success();
        }

        return new UpdateResult.Failure(new NotAuthor("you must be the author"));
    }

    public Lecture Inherit(int newId)
    {
        var lecture = new Lecture(Name, newId, Description, Content, Author, Id);

        return lecture;
    }
}