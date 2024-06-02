using Microsoft.Extensions.DependencyInjection;

namespace LZ1.Core.Tests;

public class TestsBase
{
    protected IServiceProvider CreateProvider()
    {
        return AddServices(new ServiceCollection())
            .BuildServiceProvider();
    }

    protected virtual IServiceCollection AddServices(ServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddServices();
    }
}