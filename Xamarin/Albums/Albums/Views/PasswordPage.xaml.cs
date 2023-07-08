// <copyright file="PasswordPage.xaml.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using Albums.ViewModels;
using Xamarin.Forms;

namespace Albums.Views
{
  public partial class PasswordPage : ContentPage
  {
    public PasswordPage()
    {
      InitializeComponent();

      BindingContext = _viewModel = new PasswordViewModel();
    }

    private readonly PasswordViewModel _viewModel;
  }
}
