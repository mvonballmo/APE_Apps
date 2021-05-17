// <copyright file="ItemsPage.xaml.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System;
using Albums.Models;
using Albums.ViewModels;
using Xamarin.Forms;

namespace Albums.Views
{
  public partial class ItemsPage : ContentPage
  {
    private readonly ItemsViewModel _viewModel;

    public ItemsPage()
    {
      InitializeComponent();

      BindingContext = _viewModel = new ItemsViewModel();
    }

    private async void OnItemSelected(object sender, EventArgs args)
    {
      var layout = (BindableObject)sender;
      var item = (Item)layout.BindingContext;
      await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
    }

    private async void AddItem_Clicked(object sender, EventArgs e)
    {
      await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
    }

    protected override void OnAppearing()
    {
      base.OnAppearing();

      if (_viewModel.Items.Count == 0)
      {
        _viewModel.IsBusy = true;
      }
    }
  }
}