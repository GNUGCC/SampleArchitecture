using Domain.Menu;
using Domain.Factory;
using Domain.Account;
using Domain.AppConfigure;

namespace Application.Interface;

public interface IApplicationFactory
{
    Task<IApplication> CreateApplication(IDomainRepositoryFactory factory);

    Task<IApplication> CreateApplication(IMenuRepository menuRepository, IAccountRepository accountRepository, IAppConfigRepository appConfigRepository);

    Task<IDomainRepositoryFactory> CreateDomainRepositoryFactory();
}