using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Lectures.Builder;

public class LectureBuilder
{
    private string? _name;
    private int _id;
    private string? _description;
    private string? _content;
    private SingleUser? _author;

    public LectureBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public LectureBuilder SetId(int id)
    {
        _id = id;
        return this;
    }

    public LectureBuilder SetDescription(string description)
    {
        _description = description;
        return this;
    }

    public LectureBuilder SetContent(string content)
    {
        _content = content;
        return this;
    }

    public LectureBuilder SetAuthor(SingleUser author)
    {
        _author = author;
        return this;
    }

    public Lecture Build()
    {
        return new Lecture(
            _id,
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _description ?? throw new ArgumentNullException(nameof(_description)),
            _content ?? throw new ArgumentNullException(nameof(_content)),
            _author ?? throw new ArgumentNullException(nameof(_author)));
    }
}