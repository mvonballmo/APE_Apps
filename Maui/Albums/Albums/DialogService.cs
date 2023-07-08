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
    if (Application.Current != null && Application.Current.MainPage != null)
    {
      return Application.Current.MainPage;
    }

    throw new InvalidOperationException("DialogService.MainPage cannot be null.");
  }
}