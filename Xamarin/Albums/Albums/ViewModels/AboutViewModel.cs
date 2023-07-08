// <copyright file="AboutViewModel.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System.Windows.Input;
using Albums.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Albums.ViewModels
{
  public class AboutViewModel : ViewModelBase
  {
    public AboutViewModel()
    {
      Title = "About";
      OpenWebCommand = new Command<Page>(
        async page =>
        {
          var dialogService = App.Services.GetInstance<IDialogService>();
          var result = await dialogService.Ask("Confirm", "Are you sure you want to open this web site?");
          if (result)
          {
            await Browser.OpenAsync("https://xamarin.com");
          }
        }
      );
    }

    public ICommand OpenWebCommand { get; }
  }
}