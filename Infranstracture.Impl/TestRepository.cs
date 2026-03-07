using Domain.Menu;
using Domain.Account;
using Domain.AppConfigure;

namespace Infranstracture.Test;

public readonly struct TestRepository : IMenuRepository, IAccountRepository, IAppConfigRepository
{
    Task<AppConfigure> IAppConfigRepository.AppConfigure()
    {
        throw new NotImplementedException();
    }

    Task<string[]> IMenuRepository.QueryMenu()
    {
        throw new NotImplementedException();
    }

    Task<MenuConfigure> IMenuRepository.QueryMenuConfigure()
    {
        throw new NotImplementedException();
    }
}
