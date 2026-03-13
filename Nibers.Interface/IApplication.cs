using Application.Interface.Menu;
using Domain.Account;
using Domain.AppConfigure;
using Domain.Menu;

namespace Application.Interface;

public interface IApplication
{
    Task<AppConfigure> LoadConfigure();

    Task<AccountConfigure> LoadAccountConfigure();

    Task<MenuConfigure> QueryMenuConfigure();

    Task<IMenu> GetCommandMenu();
}