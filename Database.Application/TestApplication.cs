using Delivery.Application;

using Application.Interface;
using Application.Interface.Menu;

using Domain.AppConfigure;

namespace Application.Impl;

public readonly struct TestApplication(IApplication application) : IDevlieryApplication
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