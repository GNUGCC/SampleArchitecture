using Domain.Menu;
using Domain.Command;
using Application.Interface.Menu;

namespace Domain.Application;

readonly struct TestMenu(string[] items, IMenuRepository repository) : IMenu
{
    readonly MenuItemBuilder _menuBuilder = new();

    int Count { get; }

    IMenu Context => this;

    Task<bool> IMenu.AddMenuItem(string[] titles, bool[]? predicates, Func<ICommand[]>? command)
    {
        var commands = command?.Invoke();
        _menuBuilder.AddMenuItem(name: titles[0], command: CommandCreater.Create(default));
        //var menuItem = MenuFactory.CreateMenuItem(name: Titles[0], command: Command.Create(default));
        return Task.FromResult(true);
    }

    Task<bool> IMenu.AddMenuItem(Func<MenuConfigure, int, bool> configure)
    {
        var menu = new MenuConfigure(repository)
        {
            Title = string.Empty,
            Enabled = default,
            Command = CommandCreater.Create(default)
        };

        //var menuItem = MenuFactory.CreateMenuItem(name: default, command: Command.Create(default));
        var menuItems = MenuConfigure.Build();
        return Task.FromResult(true);
    }

    Task<bool> IMenu.AddMenuItem(IMenuItem[] item)
    {
        return Task.FromResult(true);
    }

    Task IMenu.Select(string id)
    {
        return Task.CompletedTask;
    }

    Task IMenu.Select(IMenuItem menuItem)
    {
        menuItem.Command.Execute();
        return Task.CompletedTask;
    }

    Task<IMenuItem[]> IMenu.GetMenuItems()
    {
        var test1 = _menuBuilder
            .AddMenuItem("Test", command: CommandCreater.Create(TestCommand))
            .AddMenuItem("Test1", command: CommandCreater.Create(TestCommand))
            .Build();

        return test1.GetMenuItems();
    }

    async Task<IMenuItem[]> IMenu.GetMenuItems(Func<IMenuItem, bool> selector)
    {
        var menus = await repository.QueryMenu();
        return [];// [MenuFactory.CreateMenuItem(name: menus.ElementAt(0), enabled: false, command: Command.Create(OpenFile)), MenuFactory.CreateMenuItem(name: menus.ElementAt(1), command: Command.Create(SaveFile))];
    }

    static void TestCommand()
    {
    }

    static void OpenFile()
    {
    }

    static void SaveFile()
    {
    }
}
