using Microsoft.Extensions.DependencyInjection;

using Application.Impl;
using Application.Interface;
using Domain.Factory;
using Infranstracture.Test;

namespace Delivery.Extensions;

public static class DeliveryExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddApplication(new ApplicationFactory(), new DomainRepository());
        return services;
    }

    static IServiceCollection AddApplication(this IServiceCollection services, IApplicationFactory appFactory, IDomainRepositoryFactory repositoryFactory)
    {
        services.AddSingleton(appFactory.CreateApplication(repositoryFactory));
        return services;
    }

    //static IServiceCollection AddDomainRepository(this IServiceCollection services, IDomainRepositoryFactory factory)
    //{
    //    services.AddSingleton(factory.CreateMenuRepository());
    //    services.AddSingleton(factory.CreateAppConfigRepository());
    //    services.AddSingleton(factory.CreateAccountRepository());

    //    return services;
    //}
}