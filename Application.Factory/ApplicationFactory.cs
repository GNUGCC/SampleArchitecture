using Application.Interface;

using Domain.Menu;
using Domain.Factory;
using Domain.Account;
using Domain.Application;
using Domain.AppConfigure;

namespace Application.Factory;

public readonly struct ApplicationFactory : IApplicationFactory
{
    IApplication IApplicationFactory.CreateApplication(IDomainRepositoryFactory factory)
    {
        return new TestDomainApplication(default);
    }

    IApplication IApplicationFactory.CreateApplication(IMenuRepository menuRepository, IAccountRepository accountRepository, IAppConfigRepository appConfigRepository)
    {
        throw new NotImplementedException();
    }

    IDomainRepositoryFactory IApplicationFactory.CreateDomainRepositoryFactory()
    {
        throw new NotImplementedException();
    }
}