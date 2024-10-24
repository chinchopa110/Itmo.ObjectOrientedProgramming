namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects;

public class SubjectRepository
{
    private readonly List<Subject> _subjects;

    public SubjectRepository()
    {
        _subjects = new List<Subject>();
    }

    public Subject? GetIt(int subjectId)
    {
        Subject? res = _subjects.FirstOrDefault(sub => sub.Id == subjectId);
        if (res != null) _subjects.Remove(res);
        return res;
    }

    public void Add(Subject subject)
    {
        _subjects.Add(subject);
    }
}