using Application.Interface.Menu;
using Domain.Account;
using Domain.AppConfigure;

namespace Application.Interface;

public interface IApplication
{
    Task<AppConfigure> LoadConfigure();

    Task<AccountConfigure> LoadAccountConfugure();

    Task<MenuConfigure> QueryMenuConfigure();

    Task<IMenu> GetCommandMenu();
}