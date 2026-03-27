using Application.Interface;
using Application.Interface.Menu;

using Domain.Account;
using Domain.AppConfigure;
using Domain.Factory;
using Domain.Menu;
using ServiceHelper;

namespace Domain.Application;

public readonly struct TestDomainApplication(IDomainRepositoryFactory repository) : IApplication
{
    readonly IMenuRepository _menuRepository = repository.CreateMenuRepository();

    readonly IAppConfigRepository _appConfigRepository = repository.CreateAppConfigRepository();

    readonly IAccountRepository _accountRepository = repository.CreateAccountRepository();

    IApplication Context => this;

    async Task<IMenu> IApplication.GetCommandMenu()
    {
        var menus = await _menuRepository.QueryMenu();
        return await ExecuteHelper.Assert(this, context => Task.FromResult<IMenu>(new TestMenu(menus, context._menuRepository)));
    }

    Task<AccountConfigure> IApplication.LoadAccountConfigure()
    {
        return ExecuteHelper.Assert(this, context => Task.FromResult(new AccountConfigure()));
    }

    Task<AppConfigure.AppConfigure> IApplication.LoadAppConfigure(string id, params string[] args)
    {
        return ExecuteHelper.Assert(this, context => Task.FromResult(new AppConfigure.AppConfigure()));
    }

    async Task<(string, string)> IApplication.LoadConfigure()
    {
        var configure = new TaskCompletionSource<(string, string)>();
        var result = await _appConfigRepository.LoadAppName();
        //result.Export((name, line) => configure.SetResult((name, line)));

        return await configure.Task;
    }

    Task<(string[] menu, string[] menuitem)> IApplication.QueryMenu(string[] source, string[] items)
    {
        return ExecuteHelper.Assert(this, context => Task.FromResult<(string[], string[])>(([], [])));
    }

    Task<MenuConfigure> IApplication.QueryMenuConfigure()
    {
        return Task.FromResult(new MenuConfigure(_menuRepository));
    }

    Task<bool> IApplication.SelectItem(IMenuItem item)
    {
        return ExecuteHelper.Assert(this, context => Task.FromResult<bool>(default));
    }
}