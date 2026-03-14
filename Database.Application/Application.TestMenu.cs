using Domain.Menu;
using Domain.Command;
using Application.Interface.Menu;

namespace Application.Impl;

readonly struct TestMenu(string[] items, IMenuRepository repository) : IMenu
{
    int Count { get; }

    Task<bool> IMenu.AddMenuItem(string[] Titles, bool[]? predicates = default)
    {
        return Task.FromResult(true);
    }

    Task<bool> IMenu.AddMenuItem(Func<MenuConfigure, int, bool> configure)
    {
        return Task.FromResult(true);
    }

    Task<bool> IMenu.AddMenuItem(MenuItem[] item)
    {
        return Task.FromResult(true);
    }

    void IMenu.Select(MenuItem menuItem)
    {
        menuItem.Execute();
    }

    MenuItem[]? IMenu.GetMenuItems()
    {
        var test = new MenuItem("Test1", command: Command.Create(TestCommand));
        return [new("Test1"), test];        
    }

    async Task<MenuItem[]?> IMenu.GetMenuItems(Func<MenuItem, bool> selector)
    {
        var menus = await repository.QueryMenu();
        return [new(name: menus.ElementAt(0), enabled: false, command: Command.Create(MenuItemCommand)), new(name: menus.ElementAt(1), command: Command.Create(MenuItemCommand))];
    }

    static void TestCommand()
    {
    }

    static void MenuItemCommand()
    {
    }
}
