using Domain.Command;

namespace Application.Interface.Menu;

readonly struct Menu(ICollection<IMenuItem> menuItems) : IMenu, IMenuItem
{
    IMenu Context => this;

    string IMenuItem.Id => $"{menuItems.Count}";

    ICommand IMenuItem.Command => CommandCreater.Create(ShowMenuItem);

    Task<bool> IMenu.AddMenuItem(string[] titles, bool[]? predicates, Func<ICommand[]>? command)
    {
        menuItems.Add(MenuFactory.CreateMenuItem(default));
        return Task.FromResult(true);
    }

    Task<bool> IMenu.AddMenuItem(Func<MenuConfigure, int, bool> configure)
    {
        throw new NotImplementedException();
    }

    Task<bool> IMenu.AddMenuItem(IMenuItem[] item)
    {
        var size = menuItems.Count;
        foreach (var menuitem in item) menuItems.Add(menuitem);

        return Task.FromResult(size < menuItems.Count);
    }

    async Task IMenu.Select(string id)
    {
        (await Context.GetMenuItems(x => x.Id == id)).FirstOrDefault()?.Command.Execute();
    }

    async Task IMenu.Select(IMenuItem menuItem)
    {
        var items = await Context.GetMenuItems();
        if (items.Length < 1 || items.Any(x => x.Id == menuItem.Id) is false) return;

        menuItem.Command.Execute();
    }

    Task<IMenuItem[]> IMenu.GetMenuItems()
    {
        var items = menuItems.QueryMenuItem();
        return Task.FromResult(items.Length > 0 ? items : [.. menuItems.OfType<Menu>()]);
    }

    async Task<IMenuItem[]> IMenu.GetMenuItems(Func<IMenuItem, bool> selector)
    {
        return [.. (await Context.GetMenuItems()).Where(selector)];
    }

    void ShowMenuItem()
    {
        if (menuItems.Count < 1) return;
    }

    internal static Menu CreateMenu(ICollection<IMenuItem> menuItems)
    {
        return new(menuItems);
    }    
}