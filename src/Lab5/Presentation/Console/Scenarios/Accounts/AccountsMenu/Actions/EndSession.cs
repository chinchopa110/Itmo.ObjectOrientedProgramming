using Console.Scenarios.Accounts.AccountsMenu.Actions.Interfaces;
using Contracts.Users;

namespace Console.Scenarios.Accounts.AccountsMenu.Actions;

public class EndSession : IAction
{
    public string Name => "Выход";

    public void Execute(IAccountService accountService)
    {
        Environment.Exit(0);
    }
}