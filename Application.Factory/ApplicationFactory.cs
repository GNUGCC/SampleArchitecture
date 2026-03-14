using Application.Impl;
using Application.Interface;

using Domain.Account;
using Domain.AppConfigure;
using Domain.Factory;
using Domain.Menu;

namespace Application.Factory;

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