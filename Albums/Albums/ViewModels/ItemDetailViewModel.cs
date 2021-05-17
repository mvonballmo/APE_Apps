// <copyright file="ItemDetailViewModel.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using Albums.Models;

namespace Albums.ViewModels
{
  public class ItemDetailViewModel : ItemViewModelBase<Item>
  {
    public Item Item { get; set; }
    public ItemDetailViewModel(Item item = null)
    {
      Title = item?.Text;
      Item = item;
    }
  }
}
