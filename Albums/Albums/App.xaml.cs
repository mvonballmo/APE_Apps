﻿// <copyright file="App.xaml.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using Albums.Core;
using Albums.Views;
using SimpleInjector;
using Xamarin.Forms;

namespace Albums
{
  public partial class App : Application
  {
    public App()
    {
      InitializeComponent();

      var mainPage = new MainPage();
      var navigationPage = new NavigationPage(mainPage);

      Services.RegisterAlbumServices();
      Services.RegisterInstance<Page>(navigationPage);

      MainPage = navigationPage;
    }

    public static Container Services { get; } = ContainerExtensions.CreateContainer();

    protected override void OnStart()
    {
    }

    protected override void OnSleep()
    {
    }

    protected override void OnResume()
    {
    }
  }
}