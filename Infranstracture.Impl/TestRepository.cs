using Domain.Menu;
using Domain.Account;

namespace Infranstracture.Test;

public readonly struct TestRepository : IMenuRepository, IAccountRepository
{
    Task<string[]> IMenuRepository.QueryMenu()
    {
        throw new NotImplementedException();
    }

    Task<MenuConfigure> IMenuRepository.QueryMenuConfigure()
    {
        throw new NotImplementedException();
    }
}
