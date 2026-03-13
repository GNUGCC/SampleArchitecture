using Domain.Menu;
using Domain.Factory;
using Domain.Account;
using Domain.AppConfigure;

namespace Application.Interface;

public interface IApplicationFactory
{
    IApplication CreateApplication(IDomainRepositoryFactory factory);

    IApplication CreateApplication(IMenuRepository menuRepository, IAccountRepository accountRepository, IAppConfigRepository appConfigRepository);

    IDomainRepositoryFactory CreateDomainRepositoryFactory();
}