namespace Itmo.ObjectOrientedProgramming.Lab2.Prototype;

public interface IPrototype<T> where T : IPrototype<T>
{
    T Inherit(int newId);
}