namespace Albums
{
  public interface IDialogService
  {
    Task<bool> AskAsync(Page page, string message);

    Task Show(Page page, string message);
  }
}