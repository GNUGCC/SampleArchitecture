using Delivery.Application;

using Application.Interface;
using Application.Interface.Menu;
using Domain.AppConfigure;

namespace Application.Impl;

public readonly struct TestApplication(IApplication application) : IDevlieryApplication
{
    Task<AppConfigure> QueryAppConfigure()
    {
        return application.LoadAppConfigure();
    }

    Task<(string, string)> InitClientSystem()
    {
        return application.LoadConfigure();
    }

    Task<MenuConfigure> GetMenuConfigure()
    {
        return application.QueryMenuConfigure();
    }

    Task<DeliveryResponse> IDevlieryApplication.QueryAppConfigure(DeliveryRequest request)
    {
        throw new NotImplementedException();
    }

    Task<DeliveryResponse> IDevlieryApplication.InitClientSystem(DeliveryRequest request)
    {
        throw new NotImplementedException();
    }

    Task<DeliveryResponse> IDevlieryApplication.GetMenuConfigure(DeliveryRequest request)
    {
        throw new NotImplementedException();
    }
}