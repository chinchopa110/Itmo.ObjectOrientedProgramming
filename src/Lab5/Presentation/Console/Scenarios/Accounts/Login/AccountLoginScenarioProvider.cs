using Console.Scenarios.Interfaces;
using Contracts.Users;
using System.Diagnostics.CodeAnalysis;

namespace Console.Scenarios.Accounts.Login;

public class AccountLoginScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _accountService;
    private readonly ICurrentUserService _currentUser;

    public AccountLoginScenarioProvider(
        IAccountService accountService,
        ICurrentUserService currentUser)
    {
        _accountService = accountService;
        _currentUser = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new AccountLoginScenario(_accountService);
        return true;
    }
}