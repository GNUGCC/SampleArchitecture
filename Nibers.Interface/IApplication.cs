using Application.Interface.Menu;
using Domain.AppConfigure;

namespace Application.Interface;

public interface IApplication
{
    Task<AppConfigure> LoadConfigure();

    Task<MenuConfigure> QueryMenuConfigure();

    Task<IMenu> GetCommandMenu();
}