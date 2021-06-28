// <copyright file="ContainerExtensions.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System;
using System.Net.Http;
using Albums.Models;
using Albums.Services;
using JetBrains.Annotations;
using SimpleInjector;

namespace Albums.Core
{
  public static class ContainerExtensions
  {
    public static Container CreateContainer()
    {
      return new Container()
      {
        Options =
        {
          ResolveUnregisteredConcreteTypes = true,
          AllowOverridingRegistrations = true
        }
      }.RegisterAlbumServices();
    }

    public static Container RegisterAlbumServices([NotNull] this Container container)
    {
      if (container is null) { throw new ArgumentNullException(nameof(container)); }

      container.RegisterSingleton<IDataStore<Album>, AlbumsDataStore>();
      container.RegisterSingleton<IDialogService, DialogService>();
      container.RegisterSingleton<IAlbumSaver, AlbumSaver>();
      container.RegisterSingleton<IWebService<Album>, AlbumsWebService>();
      container.RegisterSingleton<IHttpClientFactory, HttpClientFactory>();

      return container;
    }
  }
}