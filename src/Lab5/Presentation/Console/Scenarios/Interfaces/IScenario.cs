namespace Console.Scenarios.Interfaces;

public interface IScenario
{
    string Name { get; }

    void Run();
}