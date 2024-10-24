namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public class UserRepository
{
    private readonly List<SingleUser> _users;

    public UserRepository()
    {
        _users = new List<SingleUser>();
    }

    public SingleUser? GetIt(int userId)
    {
        SingleUser? res = _users.FirstOrDefault(user => user.Id == userId);
        if (res != null) _users.Remove(res);
        return res;
    }

    public void Add(SingleUser user)
    {
        _users.Add(user);
    }
}