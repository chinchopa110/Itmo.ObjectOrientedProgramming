using System.Diagnostics.CodeAnalysis;

namespace Console.Scenarios.Interfaces;

public interface IScenarioProvider
{
    bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario);
}