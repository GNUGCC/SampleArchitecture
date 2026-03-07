using Domain.Menu;
using Domain.Account;

namespace Domain.Factory;

public interface IDomainRepositoryFactory
{
    IAccountRepository CreateAccountRepository();

    IMenuRepository CreateMenuRepository();
}
