namespace Albums;

public class DialogService : IDialogService
{
  public Task<bool> AskAsync(Page page, string message)
  {
    return page.DisplayAlert("Confirm", message, "Yes", "No");
  }

  public Task Show(Page page, string message)
  {
    return page.DisplayAlert("Message", message, "OK");
  }
}
