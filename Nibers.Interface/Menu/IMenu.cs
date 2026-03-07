using Domain.Configure;

namespace Application.Interface.Menu;

public interface IMenu
{
    Task<bool> AddMenuItem(string[] Titles, bool[]? predicates = default);

    Task<bool> AddMenuItem(Func<MenuConfigure, int, bool> configure);

    Task<bool> AddMenuItem(MenuItem[] item);

    void Select(MenuItem menuItem);

    MenuItem[]? GetMenuItems();

    MenuItem[]? GetMenuItems(Func<MenuItem, bool> selector);
}