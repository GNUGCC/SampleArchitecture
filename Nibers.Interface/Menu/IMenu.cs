using Domain.Command;

namespace Application.Interface.Menu;

public interface IMenu
{
    Task<bool> AddMenuItem(string[] titles, bool[]? predicates = default, Func<ICommand[]>? command = default);

    Task<bool> AddMenuItem(Func<MenuConfigure, int, bool> configure);

    Task<bool> AddMenuItem(IMenuItem[] item);

    Task Select(string id);

    Task Select(IMenuItem menuItem);

    Task<IMenuItem[]> GetMenuItems();

    Task<IMenuItem[]> GetMenuItems(Func<IMenuItem, bool> selector);
}