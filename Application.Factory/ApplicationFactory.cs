using Application.Interface;

using ServiceHelper;
using Domain.Menu;
using Domain.Factory;
using Domain.Account;
using Domain.Application;
using Domain.AppConfigure;
using Infranstracture.Test;

namespace Application.Factory;

public readonly struct ApplicationFactory : IApplicationFactory
{
    Task<IApplication> IApplicationFactory.CreateApplication(IDomainRepositoryFactory factory)
    {
        return ExecuteHelper.Assert(() => Task.FromResult<IApplication>(new TestDomainApplication(factory)));
    }

    Task<IApplication> IApplicationFactory.CreateApplication(IMenuRepository menuRepository, IAccountRepository accountRepository, IAppConfigRepository appConfigRepository)
    {
        return ExecuteHelper.Assert(() => Task.FromResult<IApplication>(new TestDomainApplication(default)));
    }

    Task<IDomainRepositoryFactory> IApplicationFactory.CreateDomainRepositoryFactory()
    {
        return ExecuteHelper.Assert(() => Task.FromResult<IDomainRepositoryFactory>(new DomainRepository()));
    }
}