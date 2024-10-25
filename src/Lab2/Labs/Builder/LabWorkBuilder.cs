using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Labs.Builder;

public class LabWorkBuilder
{
    private string? _name;
    private int _id;
    private int _balls;
    private string? _description;
    private string? _criteria;
    private SingleUser? _author;

    public LabWorkBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public LabWorkBuilder SetId(int id)
    {
        _id = id;
        return this;
    }

    public LabWorkBuilder SetBalls(int balls)
    {
        _balls = balls;
        return this;
    }

    public LabWorkBuilder SetDescription(string description)
    {
        _description = description;
        return this;
    }

    public LabWorkBuilder SetCriteria(string criteria)
    {
        _criteria = criteria;
        return this;
    }

    public LabWorkBuilder SetAuthor(SingleUser author)
    {
        _author = author;
        return this;
    }

    public LabWork Build()
    {
        return new LabWork(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _id,
            _balls,
            _description ?? throw new ArgumentNullException(nameof(_description)),
            _criteria ?? throw new ArgumentNullException(nameof(_criteria)),
            _author ?? throw new ArgumentNullException(nameof(_author)));
    }
}