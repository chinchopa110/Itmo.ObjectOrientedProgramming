namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public class SingleUser
{
    public string Name { get; private set; }

    public int Id { get; }

    public SingleUser(string name, int userId)
    {
        Name = name;
        Id = userId;
    }
}