using Application.Interface;
using Application.Interface.Menu;
using Domain.Menu;
using Domain.Account;
using Domain.AppConfigure;

namespace Application.Impl;

public readonly struct TestApplication(IMenuRepository menuRepository, IAppConfigRepository configRepository, IAccountRepository accountRepository) : IApplication
{
    async Task<IMenu> IApplication.GetCommandMenu()
    {
        var menus = await menuRepository.QueryMenu();
        return new TestMenu(menus, menuRepository);
    }

    Task<AppConfigure> IApplication.LoadConfigure()
    {
        return configRepository.AppConfigure();
    }
}