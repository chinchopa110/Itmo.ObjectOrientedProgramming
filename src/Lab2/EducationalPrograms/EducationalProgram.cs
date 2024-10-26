using Itmo.ObjectOrientedProgramming.Lab2.Repository;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalPrograms;

public class EducationalProgram : IEducationalObject
{
    public string Name { get; }

    public int Id { get; }

    private readonly Dictionary<int, Subject> _subjects;

    public SingleUser Supervisor { get; }

    public EducationalProgram(int id, string name, Dictionary<int, Subject> subjects, SingleUser user)
    {
        Name = name;
        Id = id;
        _subjects = subjects;
        Supervisor = user;
    }

    public Subject? GetSubjectOnSemester(int semester)
    {
        _subjects.TryGetValue(semester, out Subject? subject);
        return subject;
    }
}