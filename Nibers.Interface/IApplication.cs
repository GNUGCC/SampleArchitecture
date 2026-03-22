using Application.Interface.Menu;

using Domain.Account;
using Domain.AppConfigure;

namespace Application.Interface;

public interface IApplication
{
    Task<(string name, string line)> LoadConfigure();

    Task<AppConfigure> LoadAppConfigure(string id, params string[] args);

    Task<AccountConfigure> LoadAccountConfigure();

    Task<MenuConfigure> QueryMenuConfigure();

    Task<bool> SelectItem(IMenuItem item);

    Task<IMenu> GetCommandMenu();

    (string[] menu, string[] menuitem) QueryMenu(string[] source, string[] items);
}