using Application.Interface;
using Application.Interface.Menu;
using Domain.AppConfigure;

namespace Delivery.Application;

public readonly struct DevlieryApplication(IApplication application)
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

    internal Task<bool> SelectMenu(MenuItem menuItem)
    {
        return application.SelectItem(menuItem);
    }
}