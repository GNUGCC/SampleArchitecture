using Application.Menu;
using Domain.Account;

namespace Application.Interface;

public interface IApplication
{
    Task<(string name, string line)> LoadConfigure();

    Task<AccountConfigure> LoadAccountConfigure();

    Task<MenuConfigure> QueryMenuConfigure();

    Task<IMenu> GetCommandMenu();
}