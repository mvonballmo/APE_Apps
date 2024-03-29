﻿using Microsoft.Extensions.DependencyInjection;

namespace Albums.Core.Tests;

public class CounterServiceTests : TestsBase
{
  [Test]
  public void TestGetLabel()
  {
    var provider = CreateProvider();
    var counterService = provider.GetRequiredService<ICounterService>();

    Assert.That(counterService.GetLabel(), Is.EqualTo("Clicked 0 times"));

    counterService.Increment();

    Assert.That(counterService.GetLabel(), Is.EqualTo("Clicked 1 time"));

    counterService.Increment();

    Assert.That(counterService.GetLabel(), Is.EqualTo("Clicked 2 times"));
  }
}