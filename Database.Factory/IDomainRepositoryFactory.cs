using Domain.Menu;
using Domain.Account;
using Domain.AppConfigure;

namespace Domain.Factory;

public interface IDomainRepositoryFactory
{
    IAccountRepository CreateAccountRepository();

    IMenuRepository CreateMenuRepository();

    IAppConfigRepository CreateAppConfigRepository();
}
