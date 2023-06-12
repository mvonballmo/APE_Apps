using FakeItEasy;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Albums.Core.Tests;

public class CounterPersistenceTests : TestsBase
{
  [Test]
  public async Task TestAskUserToSaveAndUserSaysYes()
  {
    var provider = CreateProvider();
    var service = provider.GetRequiredService<ICounterPersistence>();
    var state = provider.GetRequiredService<ICounterState>();
    var dialogService = provider.GetRequiredService<IDialogService>();

    _flag = true;

    await service.Save(state);

    Assert.Multiple(() =>
    {
      A.CallTo(() => dialogService.AskAsync("This is the alert")).MustHaveHappenedOnceExactly();
      A.CallTo(() => dialogService.Show("Document saved.")).MustHaveHappenedOnceExactly();
    });
  }

  [Test]
  public async Task TestAskUserToSaveAndUserSaysNo()
  {
    var provider = CreateProvider();
    var service = provider.GetRequiredService<ICounterPersistence>();
    var state = provider.GetRequiredService<ICounterState>();
    var dialogService = provider.GetRequiredService<IDialogService>();

    _flag = false;

    await service.Save(state);

    Assert.Multiple(() =>
    {
      A.CallTo(() => dialogService.AskAsync("This is the alert")).MustHaveHappenedOnceExactly();
      A.CallTo(() => dialogService.Show("Document NOT saved.")).MustHaveHappenedOnceExactly();
    });
  }

  protected override IServiceCollection AddServices(ServiceCollection serviceCollection)
  {
    var fakeDialogService = A.Fake<IDialogService>();

    A.CallTo(() => fakeDialogService.AskAsync("This is the alert")).ReturnsLazily(GetFlag);

    return base
        .AddServices(serviceCollection)
        .AddSingleton(fakeDialogService);
  }

  private bool _flag;

  private bool GetFlag()
  {
    return _flag;
  }
}