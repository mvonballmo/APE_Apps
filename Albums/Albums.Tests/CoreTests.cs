// <copyright file="CoreTests.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System.Linq;
using System.Threading.Tasks;
using Albums.Core;
using Albums.Models;
using Albums.Services;
using FakeItEasy;
using NUnit.Framework;
using SimpleInjector;

namespace Albums.Tests
{
  [TestFixture]
  public class CoreTests
  {
    [Test]
    public async Task TestSaveEmptyAlbum()
    {
      var container = CreateContainer(out var dialogService);
      var albumSaver = container.GetInstance<IAlbumSaver>();

      var album = new Album();

      Assert.That(await albumSaver.TrySaveAsync(album), Is.False);
      A.CallTo(() => dialogService.Show("Validation failed", "The title cannot be empty.")).MustHaveHappenedOnceExactly();
    }

    [Test]
    public async Task TestSaveAlbumWithNoDescription()
    {
      var container = CreateContainer(out var dialogService);
      var albumSaver = container.GetInstance<IAlbumSaver>();

      var album = new Album()
      {
        Title = "Something"
      };

      Assert.That(await albumSaver.TrySaveAsync(album), Is.False);
      A.CallTo(() => dialogService.Show("Validation failed", "The description cannot be empty.")).MustHaveHappenedOnceExactly();
    }

    [Test]
    public async Task TestSaveAlbumSucceeds()
    {
      var container = CreateContainer(out var dialogService);
      var albumSaver = container.GetInstance<IAlbumSaver>();

      var album = new Album()
      {
        Title = "Something",
        Description = "Desc"
      };

      Assert.That(await albumSaver.TrySaveAsync(album), "Album should have been saved.");
      A.CallTo(() => dialogService.Show(A<string>.Ignored, A<string>.Ignored)).MustNotHaveHappened();
    }

    [Test]
    public async Task TestAlbumWebServiceGet()
    {
      var container = CreateContainer(out var _);
      var webService = container.GetInstance<IWebService<Album>>();

      var albums = await webService.Get();

      Assert.That(albums.Count(), Is.EqualTo(6));
    }

    private static Container CreateContainer(out IDialogService dialogService)
    {
      var result = ContainerExtensions.CreateContainer();

      dialogService = A.Fake<IDialogService>();

      result.RegisterInstance(dialogService);

      return result;
    }
  }
}