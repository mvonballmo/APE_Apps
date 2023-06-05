using Albums.Core;

namespace Albums;

public class DialogService : IDialogService
{
  public Task<bool> AskAsync(string message)
  {
    return GetMainPage().DisplayAlert("Confirm", message, "Yes", "No");
  }

  public Task Show(string message)
  {
    return GetMainPage().DisplayAlert("Message", message, "OK");
  }

  private static Page GetMainPage()
  {
    return Application.Current!.MainPage!;
  }
}