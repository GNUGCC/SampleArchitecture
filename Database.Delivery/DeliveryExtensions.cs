using Microsoft.Extensions.DependencyInjection;

using Application.Impl;
using Application.Interface;
using Domain.AppConfigure;
using Domain.Factory;
using Domain.Menu;
using Domain.Account;
using Infranstracture.Test;

namespace Delivery.Extensions;

public static class DeliveryExtensions
{
    public static IServiceCollection AddApplications(this IServiceCollection services)
    {
        services.AddSingleton<IApplication>(x => new TestApplication());
        services.AddSingleton<IMenuRepository>(x => new TestMenuRepository());
        services.AddSingleton<IAppConfigRepository>(x => new TestAppConfigRepository());
        services.AddSingleton<IAccountRepository>(x => new TestAccountRepository());
        services.AddSingleton<IDomainRepositoryFactory>(x => default);

        return services;
    }
}