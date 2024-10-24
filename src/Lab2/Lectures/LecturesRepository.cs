namespace Itmo.ObjectOrientedProgramming.Lab2.Lectures;

public class LecturesRepository
{
    private readonly List<Lecture> _lectures;

    public LecturesRepository()
    {
        _lectures = new List<Lecture>();
    }

    public Lecture? GetIt(int lectureId)
    {
        Lecture? res = _lectures.FirstOrDefault(lecture => lecture.Id == lectureId);
        if (res != null) _lectures.Remove(res);
        return res;
    }

    public void Add(Lecture lecture)
    {
        _lectures.Add(lecture);
    }
}