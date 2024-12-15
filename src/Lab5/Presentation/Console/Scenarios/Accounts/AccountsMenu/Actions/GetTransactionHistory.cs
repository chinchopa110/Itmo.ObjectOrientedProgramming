using Console.Scenarios.Accounts.AccountsMenu.Actions.Interfaces;
using Contracts.ResultTypes;
using Contracts.Users;
using Spectre.Console;

namespace Console.Scenarios.Accounts.AccountsMenu.Actions;

public class GetTransactionHistory : IAction
{
    public string Name => "История транзакций";

    public void Execute(IAccountService accountService)
    {
        GetHistoryResult result = accountService.GetHistory();

        if (result is GetHistoryResult.Success success)
        {
            foreach (string transaction in success.History)
            {
                AnsiConsole.MarkupLine($"[green]{transaction}[/]");
            }

            System.Console.ReadKey();
        }
        else if (result is GetHistoryResult.Failure failure)
        {
            AnsiConsole.MarkupLine($"[red]Ошибка при выполнении: {failure.Err}[/]");
            System.Console.ReadKey();
        }
    }
}