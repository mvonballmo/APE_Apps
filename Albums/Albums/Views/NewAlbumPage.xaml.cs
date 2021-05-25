// <copyright file="NewAlbumPage.xaml.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System;
using Albums.Models;
using Albums.Services;
using Xamarin.Forms;

namespace Albums.Views
{
  public partial class NewAlbumPage : ContentPage
  {
    private readonly IDialogService _dialogService;

    public Album Album { get; set; }

    public NewAlbumPage()
    {
      InitializeComponent();

      _dialogService = App.Services.GetInstance<IDialogService>();
      Album = new Album();

      BindingContext = this;
    }

    public async void Save_Clicked(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(Album.Title))
      {
        await _dialogService.Show("Validation failed", "The title cannot be empty.");
      }
      else if (string.IsNullOrEmpty(Album.Description))
      {
        await _dialogService.Show("Validation failed", "The description cannot be empty.");
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