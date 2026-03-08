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
    public static IServiceCollection AddApplicationLayers(this IServiceCollection services)
    {        
        services.AddSingleton<IMenuRepository>(x => new TestMenuRepository());
        services.AddSingleton<IAppConfigRepository>(x => new TestAppConfigRepository());
        services.AddSingleton<IAccountRepository>(x => new TestAccountRepository());
        services.AddSingleton<IDomainRepositoryFactory>(x => default);
        services.AddSingleton<IApplication>(x =>
        {
            var menuRepository = x.GetRequiredService<IMenuRepository>();
            var appConfigRepository = x.GetRequiredService<IAppConfigRepository>();
            var accountRespotiroy = x.GetRequiredService<IAccountRepository>();

            return new TestApplication(menuRepository, appConfigRepository, accountRespotiroy);
        });

        return services;
    }
}