// <copyright file="NewItemPage.xaml.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System;
using Albums.Models;
using Xamarin.Forms;

namespace Albums.Views
{
  public partial class NewItemPage : ContentPage
  {
    public Item Item { get; set; }

    public NewItemPage()
    {
      InitializeComponent();

      Item = new Item
      {
        Text = "Item name",
        Description = "This is an item description."
      };

      BindingContext = this;
    }

    private async void Save_Clicked(object sender, EventArgs e)
    {
      MessagingCenter.Send(this, "AddItem", Item);
      await Navigation.PopModalAsync();
    }

    private async void Cancel_Clicked(object sender, EventArgs e)
    {
      await Navigation.PopModalAsync();
    }
  }
}