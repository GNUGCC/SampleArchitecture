using Domain.Menu;
using Domain.Account;
using Domain.AppConfigure;

namespace Infranstracture.Test;

public readonly struct TestRepository : IMenuRepository, IAccountRepository, IAppConfigRepository
{
    Task<int> IMenuRepository.AddMenu()
    {
        throw new NotImplementedException();
    }

    Task<AppConfigure> IAppConfigRepository.AppConfigure()
    {
        throw new NotImplementedException();
    }

    Task<string[]> IMenuRepository.QueryMenu()
    {
        throw new NotImplementedException();
    }

    Task<int> IMenuRepository.UpdateMenu()
    {
        throw new NotImplementedException();
    }
}
