// <copyright file="BaseViewModel.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

using Albums.Models;
using Albums.Services;

namespace Albums.ViewModels
{
  public class BaseViewModel : INotifyPropertyChanged
  {
    public bool IsBusy
    {
      get => _isBusy;
      set => SetProperty(ref _isBusy, value);
    }

    public string Title
    {
      get => _title;
      set => SetProperty(ref _title, value);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

    protected bool SetProperty<T>(
      ref T backingStore,
      T value,
      [CallerMemberName] string propertyName = "",
      Action onChanged = null)
    {
      if (EqualityComparer<T>.Default.Equals(backingStore, value))
        return false;

      backingStore = value;
      onChanged?.Invoke();
      OnPropertyChanged(propertyName);
      return true;
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
      var changed = PropertyChanged;
      if (changed == null)
        return;

      changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private bool _isBusy;
    private string _title = string.Empty;
  }
}
