using Application.Interface;
using Application.Interface.Menu;

using Domain.Menu;
using Domain.Factory;
using Domain.Account;
using Domain.AppConfigure;

namespace Application.Impl;

public readonly struct TestApplication(IDomainRepositoryFactory repository) : IApplication
{
    readonly IMenuRepository _menuRepository = repository.CreateMenuRepository();

    readonly IAppConfigRepository _appConfigRepository = repository.CreateAppConfigRepository();

    readonly IAccountRepository _accountRepository = repository.CreateAccountRepository();

    async Task<IMenu> IApplication.GetCommandMenu()
    {
        var menus = await _menuRepository.QueryMenu();
        return new TestMenu(menus, _menuRepository);
    }

    Task<AccountConfigure> IApplication.LoadAccountConfigure()
    {
        throw new NotImplementedException();
    }

    Task<AppConfigure> IApplication.LoadAppConfigure()
    {
        throw new NotImplementedException();
    }

    async Task<(string, string)> IApplication.LoadConfigure()
    {
        var configure = new TaskCompletionSource<(string, string)>();
        var result = await _appConfigRepository.LoadAppName();
        //result.Export((name, line) => configure.SetResult((name, line)));

        return await configure.Task;
    }

    (string[] menu, string[] menuitem) IApplication.QueryMenu(string[] source, string[] items)
    {
        throw new NotImplementedException();
    }

    Task<MenuConfigure> IApplication.QueryMenuConfigure()
    {
        return Task.FromResult(new MenuConfigure(_menuRepository));
    }

    Task<bool> IApplication.SelectItem(IMenuItem item)
    {
        throw new NotImplementedException();
    }
}