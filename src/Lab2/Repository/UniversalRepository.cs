namespace Itmo.ObjectOrientedProgramming.Lab2.Repository;

public class UniversalRepository<T> where T : IEducationalObject
{
    private readonly List<T> _items;
    private int _id;

    public UniversalRepository()
    {
        _items = new List<T>();
        _id = 0;
    }

    public T? Get(int id)
    {
        T? item = _items.FirstOrDefault(i => i.Id == id);
        return item;
    }

    public void Add(T item)
    {
        _items.Add(item);
    }

    public int GenerateId()
    {
        _id++;
        return _id;
    }
}