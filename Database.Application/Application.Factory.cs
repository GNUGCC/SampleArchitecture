using Application.Interface;
using Domain.Menu;
using Domain.Factory;
using Domain.Account;
using Domain.AppConfigure;

namespace Application.Impl;

public readonly struct ApplicationFactory : IApplicationFactory
{
    IApplication IApplicationFactory.CreateApplication(IDomainRepositoryFactory factory)
    {
        return new TestApplication(factory);
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