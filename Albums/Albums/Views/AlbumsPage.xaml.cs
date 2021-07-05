// <copyright file="AlbumsPage.xaml.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Albums.Models;
using Albums.Services;
using Albums.ViewModels;
using Xamarin.Forms;

namespace Albums.Views
{
  public partial class AlbumsPage : ContentPage
  {
    public AlbumsPage()
    {
      InitializeComponent();

      BindingContext = _viewModel = new AlbumsViewModel();
    }

    private async void OnAlbumSelected(object sender, EventArgs args)
    {
      var layout = (BindableObject)sender;
      var album = (Album)layout.BindingContext;
      await Navigation.PushAsync(new AlbumDetailPage(new AlbumDetailViewModel(album)));
    }

    private async void AddAlbumClicked(object sender, EventArgs e)
    {
      await Navigation.PushModalAsync(new NavigationPage(new NewAlbumPage()));
    }

    protected override void OnAppearing()
    {
      base.OnAppearing();

      if (_viewModel.Items.Count == 0)
      {
        _viewModel.IsBusy = true;
      }
    }

    private async void LoadFromServerClickedAsync(object sender, System.EventArgs e)
    {
      var dataStore = App.Services.GetInstance<IDataStore<Album>>();

      await dataStore.Initialize();
    }

    private readonly AlbumsViewModel _viewModel;
  }
}
