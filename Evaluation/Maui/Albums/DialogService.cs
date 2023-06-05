using Albums.Core;

namespace Albums;

public class DialogService : IDialogService
{
  public Task<bool> AskAsync(string message)
  {
    return Application.Current!.MainPage!.DisplayAlert("Confirm", message, "Yes", "No");
  }

  public Task Show(string message)
  {
    return Application.Current!.MainPage!.DisplayAlert("Message", message, "OK");
  }
}