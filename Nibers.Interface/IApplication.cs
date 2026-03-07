using Application.Interface.Menu;

namespace Application.Interface;

public interface IApplication
{
    Task<AppConfigure> LoadConfigure();

    Task<IMenu> GetCommandMenu();
}