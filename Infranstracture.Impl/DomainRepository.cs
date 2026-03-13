using Domain.Menu;
using Domain.Factory;
using Domain.Account;
using Domain.AppConfigure;

namespace Infranstracture.Test;

public readonly struct DomainRepository : IDomainRepositoryFactory
{
    IAccountRepository IDomainRepositoryFactory.CreateAccountRepository()
    {
        return new TestAccountRepository();
    }

    IAppConfigRepository IDomainRepositoryFactory.CreateAppConfigRepository()
    {
        return new TestAppConfigRepository();
    }

    IMenuRepository IDomainRepositoryFactory.CreateMenuRepository()
    {
        return new TestMenuRepository();
    }
}
