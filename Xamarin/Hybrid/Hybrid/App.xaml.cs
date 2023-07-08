// <copyright file="App.xaml.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using Xamarin.Forms;

namespace Hybrid
{
  public partial class App : Application
  {
    public App()
    {
      InitializeComponent();

      MainPage = new MainPage();
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
