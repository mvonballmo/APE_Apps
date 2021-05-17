// <copyright file="AlbumDetailViewModel.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using Albums.Models;

namespace Albums.ViewModels
{
  public class AlbumDetailViewModel : ItemViewModelBase<Album>
  {
    public AlbumDetailViewModel(Album album = null)
    {
      Title = album?.Title;
      Album = album;
    }

    public Album Album { get; set; }
  }
}
