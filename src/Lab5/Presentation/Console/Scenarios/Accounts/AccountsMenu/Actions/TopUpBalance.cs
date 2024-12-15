using Console.Scenarios.Accounts.AccountsMenu.Actions.Interfaces;
using Contracts.ResultTypes;
using Contracts.Users;
using Spectre.Console;

namespace Console.Scenarios.Accounts.AccountsMenu.Actions;

public class TopUpBalance : IAction
{
    public string Name => "Пополнить счёт";

    public void Execute(IAccountService accountService)
    {
        AnsiConsole.MarkupLine("[yellow]Введите сумму пополнения[/]");
        int amount = AnsiConsole.Ask<int>("Сумма: ");

        TransactionExecuteResult result = accountService.TopUp(amount);

        if (result is TransactionExecuteResult.Success)
        {
            AnsiConsole.MarkupLine($"[green]Вы внесли {amount}.[/]");
            System.Console.ReadKey();
        }
        else if (result is TransactionExecuteResult.Failure failure)
        {
            AnsiConsole.MarkupLine($"[red]Ошибка при выполнении: {failure.Err}[/]");
            System.Console.ReadKey();
        }
    }
}