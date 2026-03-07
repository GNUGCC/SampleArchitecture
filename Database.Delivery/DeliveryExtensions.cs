using Application.Impl;
using Application.Interface;
using Domain.Factory;
using Microsoft.Extensions.DependencyInjection;

namespace Delivery.Extensions;

public static class DeliveryExtensions
{
    public static IServiceCollection AddDeliveryExtensions(this IServiceCollection services)
    {
        services.AddSingleton<IApplication>(x => new TestApplication());
        services.AddSingleton<IDomainRepositoryFactory>(x => default);

        return services;
    }
}