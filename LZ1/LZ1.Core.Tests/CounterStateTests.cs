using LZ1.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LZ1.Core.Tests;

[TestFixture]
public class CounterStateTests : TestsBase
{
    [Test]
    public void TestIncrement()
    {
        var provider = CreateProvider();
        var counterState = provider.GetRequiredService<ICounterState>();

        Assert.That(counterState.Count, Is.EqualTo(0));

        counterState.Increment();

        Assert.That(counterState.Count, Is.EqualTo(1));
    }

    [Test]
    public void TestDecrement()
    {
        // TODO Write a test for counterState.Decrement()

        Assert.Inconclusive("This test is not implemented.");
    }
}