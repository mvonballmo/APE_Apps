// <copyright file="DialogServiceExtensions.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System.Threading.Tasks;

namespace Albums.Services
{
  public static class DialogServiceExtensions
  {
    public static Task<bool> Ask(this IDialogService dialogService, string title, string message)
    {
      return dialogService.Show(title, message, "YES", "NO");
    }
  }
}
