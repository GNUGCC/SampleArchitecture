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