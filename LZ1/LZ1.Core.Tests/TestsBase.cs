using LZ1.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LZ1.Core.Tests;

public class TestsBase
{
    protected IServiceProvider CreateProvider()
    {
        return CreateServiceCollection().BuildServiceProvider();
    }

    protected IServiceCollection CreateServiceCollection()
    {
        return AddServices(new ServiceCollection());
    }

    protected virtual IServiceCollection AddServices(ServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddServices();
    }
}