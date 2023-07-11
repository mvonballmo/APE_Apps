using FakeItEasy;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Albums.Core.Tests;

[TestFixture]
public class AlbumManagerTests : TestsBase
{
  [Test]
  public async Task TestGetAll()
  {
    var provider = CreateProvider();
    var manager = provider.GetRequiredService<IAlbumManager>();

    var albums = (await manager.GetAll()).ToList();

    Assert.That(albums.Count, Is.EqualTo(6));
  }

  [Test]
  public async Task TestAdd()
  {
    var provider = CreateProvider();
    var manager = provider.GetRequiredService<IAlbumManager>();

    var newAlbum = await manager.Add(new Album { Name = "Dark Side of the Moon", Id = 16 });

    try
    {
      Assert.That(newAlbum.Name, Is.EqualTo("Dark Side of the Moon"));

      var darkSideOfTheMoon = (await manager.GetAll()).FirstOrDefault(a => a.Name == "Dark Side of the Moon");

      Assert.That(darkSideOfTheMoon, Is.Not.Null);
    }
    finally
    {
      await manager.Delete(newAlbum.Id.ToString());
    }
  }

  [Test]
  public async Task TestUpdate()
  {
    var provider = CreateProvider();
    var manager = provider.GetRequiredService<IAlbumManager>();

    var newAlbum = await manager.Add(new Album { Name = "Dark Side of the Moon", Id = 16 });

    try
    {
      Assert.That(newAlbum.Name, Is.EqualTo("Dark Side of the Moon"));

      var darkSideOfTheMoon = (await manager.GetAll()).FirstOrDefault(a => a.Name == "Dark Side of the Moon");

      Assert.That(darkSideOfTheMoon, Is.Not.Null);

      newAlbum.Name = "Wish You Were Here";

      await manager.Update(newAlbum);

      var wishYouWereHere = (await manager.GetAll()).FirstOrDefault(a => a.Name == "Wish You Were Here");

      Assert.That(wishYouWereHere, Is.Not.Null);
    }
    finally
    {
      await manager.Delete(newAlbum.Id.ToString());
    }
  }

  protected override IServiceCollection AddServices(ServiceCollection serviceCollection)
  {
    var connectivityChecker = A.Fake<IConnectivityChecker>();

    A.CallTo(() => connectivityChecker.Connected).Returns(true);

    return base
      .AddServices(serviceCollection)
      .AddSingleton(connectivityChecker);
  }
}