using Newtonsoft.Json;

using Delivery.Application;
using Domain.AppConfigure;
using Application.Interface;
using Application.Interface.Menu;

namespace Application.Impl;

public readonly struct TestApplication(IApplication application) : IDevlieryApplication
{
    Task<AppConfigure> QueryAppConfigure()
    {
        return application.LoadAppConfigure(default);
    }

    Task<(string, string)> InitClientSystem()
    {
        return application.LoadConfigure();
    }

    Task<MenuConfigure> GetMenuConfigure()
    {
        return application.QueryMenuConfigure();
    }

    async Task<DeliveryResponse> IDevlieryApplication.QueryAppConfigure(DeliveryRequest request)
    {
        var configure = await application.LoadAppConfigure(request.Parameters.First(), request.Datas);
        return new();
    }

    async Task<string> IDevlieryApplication.QueryAppConfigure(string id, string[] datas)
    {
        var configure = await application.LoadAppConfigure(id, datas);
        return JsonConvert.SerializeObject(new()
        {
        });
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