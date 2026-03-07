using Application.Interface;
using Application.Interface.Menu;
using Domain.Menu;
using Domain.AppConfigure;

namespace Application.Impl;

readonly struct TestApplication(IMenuRepository menuRepository, IAppConfigRepository configRepository) : IApplication
{
    async Task<IMenu> IApplication.GetCommandMenu()
    {
        var menus = await menuRepository.QueryMenu();
        return new Menu(menus, menuRepository);
    }

    Task<AppConfigure> IApplication.LoadConfigure()
    {
        return configRepository.AppConfigure();
    }
}