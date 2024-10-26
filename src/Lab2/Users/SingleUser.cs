using Itmo.ObjectOrientedProgramming.Lab2.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public class SingleUser : IEducationalObject
{
    public string Name { get; private set; }

    public int Id { get; }

    public SingleUser(int userId, string name)
    {
        Id = userId;
        Name = name;
    }
}