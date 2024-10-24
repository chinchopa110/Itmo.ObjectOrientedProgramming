namespace Itmo.ObjectOrientedProgramming.Lab2.Labs;

public class LabWorkRepository
{
    private readonly List<LabWork> _labWorks;

    public LabWorkRepository()
    {
        _labWorks = new List<LabWork>();
    }

    public LabWork? GetIt(int labId)
    {
        LabWork? res = _labWorks.FirstOrDefault(lab => lab.Id == labId);
        if (res != null) _labWorks.Remove(res);
        return res;
    }

    public void Add(LabWork lab)
    {
        _labWorks.Add(lab);
    }
}