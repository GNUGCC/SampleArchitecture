using Application.Interface;
using Application.Menu;

namespace Delivery.Application;

readonly struct DevlieryApplication(IApplication application)
{
    internal Task<(string, string)> InitClientSystem()
    {
        return application.LoadConfigure();
    }

    internal Task<MenuConfigure> GetMenuConfigure()
    {
        return application.QueryMenuConfigure();
    }
}