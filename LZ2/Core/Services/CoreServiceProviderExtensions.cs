using Microsoft.Extensions.DependencyInjection;

namespace Core.Services;

public static class CoreServiceProviderExtensions
{
    public static IServiceCollection CreateDefaultServiceCollection()
    {
        return new ServiceCollection().AddDefaultServices();
    }

    public static IServiceCollection AddDefaultServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddSingleton<ILocalStorage, SqliteLocalStorage>()
            .AddSingleton<LocalStorageSettings>()
            .AddSingleton<SettingsModel>()
            .AddTransient<MainPageViewModel>();
    }

    public static IServiceProvider CreateDefaultServiceProvider()
    {
        return CreateDefaultServiceCollection().BuildServiceProvider();
    }
}