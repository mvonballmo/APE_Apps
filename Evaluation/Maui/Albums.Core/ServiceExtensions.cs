using Microsoft.Extensions.DependencyInjection;

namespace Albums.Core;

public static class ServiceExtensions
{
  public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
  {
    return serviceCollection
      .AddSingleton<ICounterService, CounterService>()
      .AddSingleton<ICounterState, CounterState>();
  }
}