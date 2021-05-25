// <copyright file="App.xaml.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using Albums.Models;
using Albums.Services;
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

      Services.RegisterSingleton<IDataStore<Album>, AlbumMockDataStore>();
      Services.RegisterInstance<Page>(navigationPage);
      Services.RegisterSingleton<IDialogService, DialogService>();

      MainPage = navigationPage;
    }

    public static Container Services { get; } = CreateContainer();

    private static Container CreateContainer()
    {
      return new Container()
      {
        Options =
        {
          ResolveUnregisteredConcreteTypes = true
        }
      };
    }

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