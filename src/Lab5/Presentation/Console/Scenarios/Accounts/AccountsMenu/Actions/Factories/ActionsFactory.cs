using Console.Scenarios.Accounts.AccountsMenu.Actions.Interfaces;

namespace Console.Scenarios.Accounts.AccountsMenu.Actions.Factories;

public static class ActionsFactory
{
    public static IReadOnlyCollection<IAction> Create()
    {
        return new List<IAction>
        {
            new GetAccountBalance(),
            new TopUpBalance(),
            new WithdrawBalance(),
            new GetTransactionHistory(),
            new EndSession(),
        };
    }
}