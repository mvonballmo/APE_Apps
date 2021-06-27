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
    public Album Album { get; set; }

    public NewAlbumPage()
    {
      InitializeComponent();

      _albumSaver = App.Services.GetInstance<IAlbumSaver>();
      Album = new Album();

      BindingContext = this;
    }

    private async void Save_Clicked(object sender, EventArgs e)
    {
      if (await _albumSaver.TrySaveAsync(Album))
      {
        MessagingCenter.Send(this, "AddItem", Album);
        await Navigation.PopModalAsync();
      }
    }

    private async void Cancel_Clicked(object sender, EventArgs e)
    {
      await Navigation.PopModalAsync();
    }

    private readonly IAlbumSaver _albumSaver;
  }
}