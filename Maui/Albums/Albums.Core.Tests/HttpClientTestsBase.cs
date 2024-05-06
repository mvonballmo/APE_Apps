using FakeItEasy;
using Microsoft.Extensions.DependencyInjection;

namespace Albums.Core.Tests;

public class HttpClientTestsBase : TestsBase
{
  protected override IServiceCollection AddServices(ServiceCollection serviceCollection)
  {
    var connectivityChecker = A.Fake<IConnectivityChecker>();

    A.CallTo(() => connectivityChecker.Connected).Returns(true);

    return base
      .AddServices(serviceCollection)
      .AddSingleton(connectivityChecker);
  }
}