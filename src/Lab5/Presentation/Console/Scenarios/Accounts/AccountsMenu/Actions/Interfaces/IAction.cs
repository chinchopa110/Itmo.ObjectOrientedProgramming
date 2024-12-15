using Contracts.Users;

namespace Console.Scenarios.Accounts.AccountsMenu.Actions.Interfaces;

public interface IAction
{
    string Name { get; }

    void Execute(IAccountService accountService);
}