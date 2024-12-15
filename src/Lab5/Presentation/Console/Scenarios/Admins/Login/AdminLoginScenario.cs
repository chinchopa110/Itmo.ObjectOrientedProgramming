using Console.Scenarios.Admins.AdminMenu;
using Console.Scenarios.Interfaces;
using Contracts.Admins;
using Spectre.Console;

namespace Console.Scenarios.Admins.Login;

public class AdminLoginScenario : IScenario
{
    private readonly IAdminService _adminService;
    private readonly AdminInteractionMenu _adminInteractionMenu;

    public AdminLoginScenario(IAdminService adminService)
    {
        _adminService = adminService;
        _adminInteractionMenu = new AdminInteractionMenu();
    }

    public string Name => "Войти как администратор";

    public void Run()
    {
        string systemPassword = AnsiConsole.Ask<string>("Введите ваш системный пароль ");
        _adminService.Login(systemPassword);

        AnsiConsole.MarkupLine("[green]Вы вошли в систему как администратор![/]");
        System.Console.ReadKey();

        _adminInteractionMenu.Display();
    }
}