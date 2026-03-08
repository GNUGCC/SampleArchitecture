using Domain.Menu;
using Application.Interface.Menu;

namespace Application.Impl;

readonly struct TestMenu(string[] items, IMenuRepository repository) : IMenu
{
    public int Count { get; }

    public Task<bool> AddMenuItem(string[] Titles, bool[]? predicates = default)
    {
        return Task.FromResult(true);
    }

    public Task<bool> AddMenuItem(Func<MenuConfigure, int, bool> configure)
    {
        return Task.FromResult(true);
    }

    public Task<bool> AddMenuItem(MenuItem[] item)
    {
        return Task.FromResult(true);
    }

    public void Select(MenuItem menuItem)
    {
        menuItem.Execute();
    }

    public MenuItem[]? GetMenuItems()
    {
        var test = new MenuItem("Test1");
        return [new("Test1"), test];
    }

    public MenuItem[]? GetMenuItems(Func<MenuItem, bool> selector)
    {
        return [];
    }
}
