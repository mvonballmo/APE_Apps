// <copyright file="ListViewModelBase.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Albums.ViewModels
{
  public class ListViewModelBase<TItem, TPage> : ItemViewModelBase<TItem>
    where TPage : class
  {
    public ObservableCollection<TItem> Items { get; set; }

    public Command LoadItemsCommand { get; set; }

    public ListViewModelBase()
    {
      Title = "Browse";
      Items = new ObservableCollection<TItem>();
      LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

      MessagingCenter.Subscribe<TPage, TItem>(this, "AddItem", async (obj, item) =>
      {
        Items.Add(item);
        await DataStore.AddItemAsync(item);
      });
    }

    private async Task ExecuteLoadItemsCommand()
    {
      IsBusy = true;

      try
      {
        Items.Clear();
        var items = await DataStore.GetItemsAsync(true);
        foreach (var item in items)
        {
          Items.Add(item);
        }
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex);
      }
      finally
      {
        IsBusy = false;
      }
    }
  }
}