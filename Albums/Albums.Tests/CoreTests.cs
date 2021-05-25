// <copyright file="CoreTests.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using Albums.Core;
using Albums.Models;
using Albums.Services;
using FakeItEasy;
using NUnit.Framework;

namespace Albums.Tests
{
  [TestFixture]
  public class CoreTests
  {
    [Test]
    public async Task TestSaveEmptyAlbum()
    {
      var container = ContainerExtensions
        .CreateContainer()
        .RegisterAlbumServices();

      var dialogService = A.Fake<IDialogService>();

      container.RegisterInstance(dialogService);

      var albumSaver = container.GetInstance<IAlbumSaver>();

      var album = new Album();

      Assert.That(await albumSaver.TrySaveAsync(album), Is.False);
      A.CallTo(() => dialogService.Show(A<string>.Ignored, A<string>.Ignored)).MustHaveHappenedOnceExactly();
    }
  }
}