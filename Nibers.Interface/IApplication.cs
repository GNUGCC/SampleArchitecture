using Application.Interface.Menu;
using Domain.Account;
using Domain.AppConfigure;

namespace Application.Interface;

public interface IApplication
{
    Task<(string name, string line)> LoadConfigure();

    Task<AppConfigure> QueryAppConfigure();

    Task<AccountConfigure> LoadAccountConfigure();

    Task<MenuConfigure> QueryMenuConfigure();

    Task<IMenu> GetCommandMenu();
}