namespace Albums;

public class DialogService : IDialogService
{
  public MainPage? Page { get; internal set; }

  public Task<bool> AskAsync(string message)
  {
    return Page!.DisplayAlert("Confirm", message, "Yes", "No");
  }

  public Task Show(string message)
  {
    return Page!.DisplayAlert("Message", message, "OK");
  }
}
