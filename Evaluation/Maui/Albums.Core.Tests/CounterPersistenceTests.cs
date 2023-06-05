using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Albums.Core.Tests;

public class CounterPersistenceTests : TestsBase
{
  [Test]
  public async Task TestAskUserToSave()
  {
    var provider = CreateProvider();
    var service = provider.GetRequiredService<ICounterPersistence>();
    var state = provider.GetRequiredService<ICounterState>();
    var dialogService = (TestDialogService)provider.GetRequiredService<IDialogService>();

    Assert.Multiple(() =>
    {
      Assert.That(dialogService.AskMessage, Is.EqualTo(string.Empty));
      Assert.That(dialogService.ShowMessage, Is.EqualTo(string.Empty));
    });

    await service.Save(state);

    Assert.Multiple(() =>
    {
      Assert.That(dialogService.AskMessage, Is.EqualTo("This is the alert"));
      Assert.That(dialogService.ShowMessage, Is.EqualTo("Document saved."));
    });
  }

  protected override IServiceCollection AddServices(ServiceCollection serviceCollection)
  {
    return base
        .AddServices(serviceCollection)
        .AddSingleton<IDialogService, TestDialogService>();
  }

  public class TestDialogService : IDialogService
  {
    public string AskMessage { get; set; } = string.Empty;

    public string ShowMessage { get; set; } = string.Empty;

    public Task<bool> AskAsync(string message)
    {
      AskMessage = message;

      return Task.FromResult(true);
    }

    public Task Show(string message)
    {
      ShowMessage = message;

      return Task.CompletedTask;
    }
  }

  // TODO FakeItEasy
}