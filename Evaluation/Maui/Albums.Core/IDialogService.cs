namespace Albums.Core
{
  public interface IDialogService
  {
    Task<bool> AskAsync(string message);

    Task Show(string message);
  }
}