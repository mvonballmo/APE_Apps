using Microsoft.Extensions.DependencyInjection;

namespace Albums.Core.Tests;

[TestFixture]
public class HttpClientManagerTests : HttpClientTestsBase
{
  [Test]
  public async Task TestAuthentication()
  {
    var provider = CreateProvider();
    var httpSettings = provider.GetRequiredService<IHttpSettings>();
    var httpClientManager = provider.GetRequiredService<IHttpClientManager>();

    httpSettings.RequiresAuthentication = true;

    var client = await httpClientManager.GetClient();
    var result = await client.GetStringAsync("albums");

    Assert.That(result, Is.EqualTo("""["dummy"]"""));
  }
}