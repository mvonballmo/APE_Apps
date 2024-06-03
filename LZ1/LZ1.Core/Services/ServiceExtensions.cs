using Microsoft.Extensions.DependencyInjection;

namespace LZ1.Core.Services;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddSingleton<ICounterService, CounterService>()
            .AddSingleton<ICounterState, CounterState>();
    }
}