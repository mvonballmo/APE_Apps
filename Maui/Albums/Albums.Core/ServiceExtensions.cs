﻿using Microsoft.Extensions.DependencyInjection;

namespace Albums.Core;

public static class ServiceExtensions
{
  public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
  {
    return serviceCollection
      .AddSingleton<ICounterService, CounterService>()
      .AddSingleton<ICounterPersistence, CounterPersistence>()
      .AddSingleton<ICounterState, CounterState>()
      .AddSingleton<IConnectivityChecker, ConnectivityChecker>()
      .AddSingleton<IHttpSettings, HttpSettings>()
      .AddSingleton<IHttpClientManager, HttpClientManager>()
      .AddSingleton<IAlbumManager, AlbumManager>()
      .AddSingleton<IAlbumFactory, AlbumFactory>();
  }
}