// <copyright file="NewAlbumPage.xaml.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System;
using Albums.Models;
using Xamarin.Forms;

namespace Albums.Views
{
  public partial class NewAlbumPage : ContentPage
  {
    public Album Album { get; set; }

    public NewAlbumPage()
    {
      InitializeComponent();

      Album = new Album
      {
        Title = "Album name",
        Description = "This album contains vacation photos."
      };

      BindingContext = this;
    }

    private async void Save_Clicked(object sender, EventArgs e)
    {
      MessagingCenter.Send(this, "AddItem", Album);
      await Navigation.PopModalAsync();
    }

    private async void Cancel_Clicked(object sender, EventArgs e)
    {
      await Navigation.PopModalAsync();
    }
  }
}