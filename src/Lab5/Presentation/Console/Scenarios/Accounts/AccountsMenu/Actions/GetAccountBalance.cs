using Console.Scenarios.Accounts.AccountsMenu.Actions.Interfaces;
using Contracts.ResultTypes;
using Contracts.Users;
using Spectre.Console;

namespace Console.Scenarios.Accounts.AccountsMenu.Actions;

public class GetAccountBalance : IAction
{
    public string Name => "Баланс счета";

    public void Execute(IAccountService accountService)
    {
        GetBalanceResult result = accountService.GetBalance();

        if (result is GetBalanceResult.Success success)
        {
            AnsiConsole.MarkupLine($"[green]Ваш баланс: {success.Balance}[/]");
            System.Console.ReadKey();
        }
        else if (result is GetBalanceResult.Failure failure)
        {
            AnsiConsole.MarkupLine($"[red]Ошибка при выполнении: {failure.Err}[/]");
            System.Console.ReadKey();
        }
    }
}