// <copyright file="App.xaml.cs" company="Marco von Ballmoos">
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

      Services = ContainerExtensions.CreateContainer();
      Services.RegisterInstance<Page>(navigationPage);

      MainPage = navigationPage;
    }

    public static Container Services { get; private set; }

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