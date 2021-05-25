// <copyright file="ItemViewModelBase.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using Albums.Services;
using Xamarin.Forms;

namespace Albums.ViewModels
{
  public class ItemViewModelBase<T> : ViewModelBase
  {
    protected IDataStore<T> DataStore => App.Services.GetInstance<IDataStore<T>>();
  }
}
