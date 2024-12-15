using Console.Scenarios.Accounts.AccountsMenu.Actions.Interfaces;
using Contracts.ResultTypes;
using Contracts.Users;
using Spectre.Console;

namespace Console.Scenarios.Accounts.AccountsMenu.Actions;

public class WithdrawBalance : IAction
{
    public string Name => "Снять со счёта";

    public void Execute(IAccountService accountService)
    {
        AnsiConsole.MarkupLine("[yellow]Введите сумму для снятия[/]");
        int amount = AnsiConsole.Ask<int>("Сумма: ");

        TransactionExecuteResult result = accountService.Withdraw(amount);

        if (result is TransactionExecuteResult.Success)
        {
            AnsiConsole.MarkupLine($"[green]Вы сняли {amount}.[/]");
            System.Console.ReadKey();
        }
        else if (result is TransactionExecuteResult.Failure failure)
        {
            AnsiConsole.MarkupLine($"[red]Ошибка при выполнении: {failure.Err}[/]");
            System.Console.ReadKey();
        }
    }
}