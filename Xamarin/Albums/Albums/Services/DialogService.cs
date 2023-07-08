// <copyright file="DialogService.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using Xamarin.Forms;

namespace Albums.Services
{
  public class DialogService : IDialogService
  {
    public DialogService(Page page)
    {
      _page = page;
    }

    public async Task Show(string title, string message)
    {
      await _page.DisplayAlert(title, message, "OK");
    }

    public async Task<bool> Show(string title, string message, string positive, string negative)
    {
      return await _page.DisplayAlert(title, message, positive, negative);
    }

    private readonly Page _page;
  }
}
