using Application.Interface;
using Application.Interface.Menu;
using Domain.AppConfigure;

namespace Delivery.Application;

public interface IDevlieryApplication
{
    Task<AppConfigure> QueryAppConfigure();

    Task<(string, string)> InitClientSystem();

    Task<MenuConfigure> GetMenuConfigure();
}

readonly struct DevlieryApplication(IApplication application) : IDevlieryApplication
{
    Task<AppConfigure> IDevlieryApplication.QueryAppConfigure()
    {
        return application.LoadAppConfigure();
    }

    Task<(string, string)> IDevlieryApplication.InitClientSystem()
    {
        return application.LoadConfigure();
    }

    Task<MenuConfigure> IDevlieryApplication.GetMenuConfigure()
    {
        return application.QueryMenuConfigure();
    }
}