using Domain.Command;

namespace Application.Interface.Menu;

public readonly struct MenuItemBuilder
{
    readonly ICollection<IMenuItem> _menuitem;

    public MenuItemBuilder()
    {
        _menuitem = [];
    }

    public MenuItemBuilder AddMenuItem(string name, string? description = default, bool enabled = true, ICommand? command = default)
    {
        _menuitem.Add(MenuFactory.CreateMenuItem(name, description, enabled, command));
        return this;
    }

    public MenuItemBuilder AddMenuItem(string name, string? description = default, bool enabled = true, Action? command = default)
    {
        return AddMenuItem(name, description, enabled, CommandCreater.Create(() => command?.Invoke()));
    }

    public IMenu Build()
    {
        return MenuFactory.CreateMenu(_menuitem);
    }
}

public readonly struct MenuFactory
{
    public static MenuItemBuilder CreateMenuItemBuilder()
    {
        return new();
    }

    public static IMenu CreateMenu(Action<MenuItemBuilder> configure)
    {
        var itemBuilder = CreateMenuItemBuilder();
        configure.Invoke(itemBuilder);

        return itemBuilder.Build();
    }

    internal static IMenu CreateMenu(ICollection<IMenuItem> menuItems)
    {
        return new Menu(menuItems);
    }

    internal static IMenuItem CreateMenuItem(string name, string? description = default, bool enabled = true, ICommand? command = default)
    {
        return new MenuItem(name, description, enabled, CommandCreater.Create(() => command?.Execute()));
    }

    internal readonly struct MenuItem(string name, string description, bool enabled , ICommand command) : IMenuItem
    {
        readonly string _guid = $"{Guid.NewGuid()}";

        ICommand IMenuItem.Command { get; } = CommandCreater.Create(command.Execute);

        string IMenuItem.Id  => _guid;

        internal void Execute()
        {
            Execute((this as IMenuItem).Command);
        }

        internal void Execute(ICommand? command)
        {
            if (enabled is false || command is null) return;
            command.Execute();
        }
    }
}

public static class MenuItemExtensions
{
    public static IMenuItem[] QueryMenuItem(this ICollection<IMenuItem> menuItem)
    {
        return [.. menuItem.OfType<MenuFactory.MenuItem>()];
    }
}