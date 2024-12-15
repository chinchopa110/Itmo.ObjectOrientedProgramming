using Console.Runner;
using Console.Scenarios.Accounts.Login;
using Console.Scenarios.Admins.Login;
using Console.Scenarios.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, AccountLoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AdminLoginScenarioProvider>();

        return collection;
    }
}