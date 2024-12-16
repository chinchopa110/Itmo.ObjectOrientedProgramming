using Console.Scenarios.Accounts.AccountsMenu.Actions.Interfaces;
using Console.Scenarios.Accounts.Factories;
using Console.Scenarios.PresentationMenu;
using Contracts.Users;
using Spectre.Console;

namespace Console.Scenarios.Accounts.AccountsMenu;

public class AccountInteractionMenu : IMenu
{
    private readonly IAccountService _accountService;
    private readonly IReadOnlyCollection<IAction> _actions;

    public AccountInteractionMenu(IAccountService accountService)
    {
        _accountService = accountService;
        _actions = ActionsFactory.Create();
    }

    public void Display()
    {
        SelectionPrompt<IAction> selector = new SelectionPrompt<IAction>()
            .Title("Выберите действие:")
            .AddChoices(_actions)
            .UseConverter(x => x.Name);

        IAction action = AnsiConsole.Prompt(selector);
        action.Execute(_accountService);
    }
}