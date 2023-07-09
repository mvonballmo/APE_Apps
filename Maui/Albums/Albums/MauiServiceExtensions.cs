using Albums.Core;

namespace Albums;

public static class MauiServiceExtensions
{
  public static IServiceCollection AddMauiServices(this IServiceCollection serviceCollection)
  {
    return serviceCollection
      .AddSingleton<IDialogService, DialogService>()
      .AddSingleton<IConnectivityChecker, ConnectivityChecker>();
  }
}