using FakeItEasy;
using Microsoft.Extensions.DependencyInjection;

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

    SetUpDialog(true);

    await service.Save(state);

    Assert.Multiple(() =>
    {
      A.CallTo(() => dialogService.AskAsync(A<string>.Ignored)).MustHaveHappenedOnceExactly();
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

    SetUpDialog(false);

    await service.Save(state);

    Assert.Multiple(() =>
    {
      A.CallTo(() => dialogService.AskAsync(A<string>.Ignored)).MustHaveHappenedOnceExactly();
      A.CallTo(() => dialogService.Show("Document NOT saved.")).MustHaveHappenedOnceExactly();
    });
  }

  protected override IServiceCollection AddServices(ServiceCollection serviceCollection)
  {
    _fakeDialogService = A.Fake<IDialogService>();

    return base
        .AddServices(serviceCollection)
        .AddSingleton(_fakeDialogService);
  }

  private void SetUpDialog(bool askResult)
  {
    A.CallTo(() => _fakeDialogService!.AskAsync(A<string>.Ignored)).Returns(askResult);
  }

  private IDialogService? _fakeDialogService;
}