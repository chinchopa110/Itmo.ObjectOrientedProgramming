using Console.Scenarios.PresentationMenu;
using Spectre.Console;

namespace Console.Scenarios.Admins.AdminMenu;

public class AdminInteractionMenu : IMenu
{
    public void Display()
    {
        AnsiConsole.MarkupLine("[red]В этой версии приложения меню администратора не доступно:)[/]");
        AnsiConsole.MarkupLine("Выйти из системы");
        System.Console.ReadKey();
        Environment.Exit(0);
    }
}