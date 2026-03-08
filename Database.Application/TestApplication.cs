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

    Task<AccountConfigure> IApplication.LoadAccountConfugure()
    {
        return _accountRepository.LoadAccountConfigure();
    }

    Task<AppConfigure> IApplication.LoadConfigure()
    {
        return _appConfigRepository.LoadAppConfigure();
    }

    Task<MenuConfigure> IApplication.QueryMenuConfigure()
    {
        return Task.FromResult(new MenuConfigure());
    }
}