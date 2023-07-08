// <copyright file="AlbumSaver.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Albums.Models;

namespace Albums.Services
{
  public class AlbumSaver : IAlbumSaver
  {
    public AlbumSaver(IDialogService dialogService)
    {
      _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
    }

    public async Task<bool> TrySaveAsync(Album album)
    {
      if (album is null) { throw new ArgumentNullException(nameof(album)); }

      if (string.IsNullOrEmpty(album.Title))
      {
        await _dialogService.Show("Validation failed", "The title cannot be empty.");

        return false;
      }

      if (string.IsNullOrEmpty(album.Description))
      {
        await _dialogService.Show("Validation failed", "The description cannot be empty.");

        return false;
      }

      return true;
    }

    private readonly IDialogService _dialogService;
  }
}
