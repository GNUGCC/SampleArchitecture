using Microsoft.Extensions.DependencyInjection;

using Application.Impl;
using Application.Interface;
using Domain.AppConfigure;
using Domain.Factory;
using Domain.Menu;
using Domain.Account;

namespace Delivery.Extensions;

public static class DeliveryExtensions
{
    public static IServiceCollection AddApplications(this IServiceCollection services)
    {
        services.AddSingleton<IApplication>(x => new TestApplication());
        services.AddSingleton<IMenuRepository>(x => default);
        services.AddSingleton<IAppConfigRepository>(x => default);
        services.AddSingleton<IAccountRepository>(x => default);
        services.AddSingleton<IDomainRepositoryFactory>(x => default);

        return services;
    }
}