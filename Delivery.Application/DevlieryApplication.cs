using Application.Interface;
using Application.Interface.Menu;
using Domain.AppConfigure;

namespace Delivery.Application;

readonly struct DevlieryApplication(IApplication application)
{
    internal Task<AppConfigure> QueryAppConfigure()
    {
        return application.LoadAppConfigure();
    }

    internal Task<(string, string)> InitClientSystem()
    {
        return application.LoadConfigure();
    }

    internal Task<MenuConfigure> GetMenuConfigure()
    {
        return application.QueryMenuConfigure();
    }
}