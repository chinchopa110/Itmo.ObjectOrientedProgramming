using Itmo.ObjectOrientedProgramming.Lab2.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalPrograms;

public class EducationalProgram
{
    public string Name { get; }

    public int Id { get; }

    public Dictionary<int, Subject> Subjects { get; }

    public SingleUser Supervisor { get; }

    public EducationalProgram(string name, int id, Dictionary<int, Subject> subjects, SingleUser user)
    {
        Name = name;
        Id = id;
        Subjects = subjects;
        Supervisor = user;
    }
}