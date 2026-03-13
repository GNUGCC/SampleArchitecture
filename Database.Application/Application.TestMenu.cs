using Domain.Menu;
using Application.Menu;

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
        var test = new MenuItem("Test1");
        return [new("Test1"), test];
    }

    MenuItem[]? IMenu.GetMenuItems(Func<MenuItem, bool> selector)
    {
        return [];
    }
}
