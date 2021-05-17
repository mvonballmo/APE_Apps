// <copyright file="ItemDetailPage.xaml.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using Albums.Models;
using Albums.ViewModels;
using Xamarin.Forms;

namespace Albums.Views
{
  public partial class ItemDetailPage : ContentPage
  {
    private readonly ItemDetailViewModel _viewModel;

    public ItemDetailPage(ItemDetailViewModel viewModel)
    {
      InitializeComponent();

      BindingContext = _viewModel = viewModel;
    }

    public ItemDetailPage()
    {
      InitializeComponent();

      var item = new Item
      {
        Text = "Item 1",
        Description = "This is an item description."
      };

      _viewModel = new ItemDetailViewModel(item);
      BindingContext = _viewModel;
    }
  }
}