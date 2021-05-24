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

      Album = new Album();

      BindingContext = this;
    }

    private async void Save_Clicked(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(Album.Title))
      {
        await DisplayAlert("Validation failed", "The title cannot be empty.", "OK");
      }
      else if (string.IsNullOrEmpty(Album.Description))
      {
        await DisplayAlert("Validation failed", "The description cannot be empty.", "OK");
      }
      else
      {
        MessagingCenter.Send(this, "AddItem", Album);
        await Navigation.PopModalAsync();
      }
    }

    private async void Cancel_Clicked(object sender, EventArgs e)
    {
      await Navigation.PopModalAsync();
    }
  }
}