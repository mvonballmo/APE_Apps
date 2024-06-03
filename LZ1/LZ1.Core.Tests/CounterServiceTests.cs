using LZ1.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LZ1.Core.Tests;

public class CounterServiceTests : TestsBase
{
    [Test]
    public void TestGetLabelOnIncrement()
    {
        var provider = CreateProvider();
        var counterService = provider.GetRequiredService<ICounterService>();

        Assert.That(counterService.GetLabel(), Is.EqualTo("Clicked 0 times"));

        counterService.Increment();

        Assert.That(counterService.GetLabel(), Is.EqualTo("Clicked 1 time"));

        counterService.Increment();

        Assert.That(counterService.GetLabel(), Is.EqualTo("Clicked 2 times"));
    }

    [TestCase(true)]
    [TestCase(false)]
    public async Task TestTryIncrement(bool askResult)
    {
        var testDialogService = new TestDialogService();

        var provider = CreateServiceCollection()
            .AddSingleton<IDialogService>(testDialogService)
            .BuildServiceProvider();

        var counterService = provider.GetRequiredService<ICounterService>();

        var incrementResult = await counterService.TryIncrement();

        Assert.That(incrementResult, Is.EqualTo(askResult));
        Assert.That(testDialogService.LastMessage, Is.EqualTo("Are you sure you want to increment?"));
    }

    [Test]
    public async Task TestTryIncrementConfirmationMessage()
    {
        var testDialogService = new TestDialogService();

        var provider = CreateServiceCollection()
            .AddSingleton<IDialogService>(testDialogService)
            .BuildServiceProvider();

        var counterService = provider.GetRequiredService<ICounterService>();

        await counterService.TryIncrement();

        Assert.That(testDialogService.LastMessage, Is.EqualTo("Are you sure you want to increment?"));
    }

    [Test]
    public void TestGetLabelOnDecrement()
    {
        Assert.Inconclusive("This test is not implemented.");
    }

    [TestCase(true)]
    [TestCase(false)]
    public async Task TestTryDecrement(bool askResult)
    {
        Assert.Inconclusive("This test is not implemented.");
    }

    [Test]
    public async Task TestTryDecrementConfirmationMessage()
    {
        Assert.Inconclusive("This test is not implemented.");
    }

    protected override IServiceCollection AddServices(ServiceCollection serviceCollection)
    {
        return base.AddServices(serviceCollection).AddSingleton<IDialogService, TestDialogService>();
    }

    private class TestDialogService : IDialogService
    {
        public bool AskResult { get; set; } = true;

        public string LastMessage { get; private set; } = string.Empty;

        public Task<bool> AskAsync(string message)
        {
            LastMessage = message;

            return Task.FromResult(AskResult);
        }

        public Task Show(string message)
        {
            LastMessage = message;

            return Task.CompletedTask;
        }
    }
}