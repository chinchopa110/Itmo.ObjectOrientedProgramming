using Console.Scenarios.Interfaces;
using Contracts.Admins;
using Contracts.ResultTypes;
using Spectre.Console;

namespace Console.Scenarios.Admins.Create;

public class AddAdminScenario : IScenario
{
    private readonly ICreateAdminService _createAccountService;

    public AddAdminScenario(ICreateAdminService createAccountService)
    {
        _createAccountService = createAccountService;
    }

    public string Name => "Add new admin";

    public void Run()
    {
        string systemPassword = AnsiConsole.Ask<string>("Введите новый системный пароль");
        CreateResults result = _createAccountService.CreateAdmin(systemPassword);

        if (result is CreateResults.Success)
        {
            AnsiConsole.MarkupLine("[green]Админ создан успешно![/]");
            System.Console.ReadKey();
        }
        else if (result is CreateResults.Failure failure)
        {
            AnsiConsole.MarkupLine($"[red]Ошибка при создании админа: {failure.Err}[/]");
            System.Console.ReadKey();
        }
    }
}