using Console.Scenarios.Interfaces;
using Contracts.ResultTypes;
using Contracts.Users;
using Spectre.Console;

namespace Console.Scenarios.Accounts.Create;

public class AddAccountScenario : IScenario
{
    private readonly ICreateAccountService _createAccountService;

    public AddAccountScenario(ICreateAccountService createAccountService)
    {
        _createAccountService = createAccountService;
    }

    public string Name => "Создать новый счёт";

    public void Run()
    {
        long accountNumber = AnsiConsole.Ask<long>("Введите номер счета: ");
        string pinCode = AnsiConsole.Ask<string>("Введите PIN-код: ");

        CreateResults result = _createAccountService.CreateAccount(accountNumber, pinCode);

        if (result is CreateResults.Success)
        {
            AnsiConsole.MarkupLine($"[green]Счёт {accountNumber} создан успешно![/]");
            System.Console.ReadKey();
        }
        else if (result is CreateResults.Failure failure)
        {
            AnsiConsole.MarkupLine($"[red]Ошибка при создании аккаунта: {failure.Err}[/]");
            System.Console.ReadKey();
        }
    }
}