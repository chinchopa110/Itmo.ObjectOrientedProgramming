using Console.Scenarios.Accounts.AccountsMenu;
using Console.Scenarios.Interfaces;
using Contracts.ResultTypes;
using Contracts.Users;
using Spectre.Console;

namespace Console.Scenarios.Accounts.Login;

public class AccountLoginScenario : IScenario
{
    private readonly IAccountService _accountService;
    private readonly AccountInteractionMenu _menu;

    public AccountLoginScenario(IAccountService accountService)
    {
        _accountService = accountService;
        _menu = new AccountInteractionMenu(accountService);
    }

    public string Name => "Авторизация по счету";

    public void Run()
    {
        long accountNumber = AnsiConsole.Ask<long>("Введите ваш номер счета: ");
        string pinCode = AnsiConsole.Ask<string>("Введите ваш PIN-код: ");

        UserLoginResult result = _accountService.Login(accountNumber, pinCode);

        if (result is UserLoginResult.Success)
        {
            AnsiConsole.MarkupLine("[green]Вы вошли в систему![/]");
            AnsiConsole.MarkupLine("Продолжить");
            System.Console.ReadKey();
            while (true)
            {
                System.Console.Clear();
                _menu.Display();
            }
        }

        if (result is UserLoginResult.Failure failure)
        {
            AnsiConsole.MarkupLine($"[red]Ошибка при входе:[/] {failure.Err}");
            System.Console.ReadKey();
        }
    }
}