using Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Tests;

public class TestsBase
{
    protected IServiceProvider CreateServiceProvider()
    {
        var defaultServiceCollection = CoreServiceProviderExtensions.CreateDefaultServiceCollection();

        return AddServices(defaultServiceCollection)
            .BuildServiceProvider();
    }

    protected virtual IServiceCollection AddServices(IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}