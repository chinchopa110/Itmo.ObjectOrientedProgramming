using Console.Scenarios.Interfaces;
using Contracts.Admins;
using System.Diagnostics.CodeAnalysis;

namespace Console.Scenarios.Admins.Login;

public class AdminLoginScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _adminService;
    private readonly ICurrentAdminService _currentAdmin;

    public AdminLoginScenarioProvider(
        IAdminService adminService,
        ICurrentAdminService currentAdmin)
    {
        _adminService = adminService;
        _currentAdmin = currentAdmin;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAdmin.Admin is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new AdminLoginScenario(_adminService);
        return true;
    }
}