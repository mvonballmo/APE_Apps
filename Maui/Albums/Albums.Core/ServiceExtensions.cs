using Microsoft.Extensions.DependencyInjection;

namespace Albums.Core;

public static class ServiceExtensions
{
  public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
  {
    return serviceCollection
      .AddSingleton<ICounterService, CounterService>()
      .AddSingleton<ICounterPersistence, CounterPersistence>()
      .AddSingleton<ICounterState, CounterState>()
      .AddSingleton<IHttpSettings, HttpSettings>()
      .AddSingleton<IHttpClientManager, HttpClientManager>()
      .AddSingleton<IAlbumManager, AlbumManager>()
      .AddSingleton<IAlbumTools, AlbumTools>()
      .AddSingleton<IPersonManager, PersonManager>()
      .AddSingleton<IPersonTools, PersonTools>();
  }
}