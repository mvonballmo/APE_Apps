// <copyright file="CoreTests.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System;
using Albums.Core;
using Albums.Views;
using NUnit.Framework;
using Xamarin.Forms;

namespace Albums.Tests
{
  [TestFixture]
  public class CoreTests
  {
    [Test]
    public void TestSave()
    {
      var container = ContainerExtensions
        .CreateContainer()
        .RegisterAlbumServices();

      var newAlbumPage = new NewAlbumPage();

      container.RegisterInstance<Page>(newAlbumPage);

      newAlbumPage.Save_Clicked(null, EventArgs.Empty);
    }
  }
}