namespace Albums.Core
{
  public class CounterPersistence : ICounterPersistence
  {
    private readonly IDialogService _dialogService;

    public CounterPersistence(IDialogService dialogService)
    {
      _dialogService = dialogService;
    }

    public async Task Save(ICounterState state)
    {
      var answer = await _dialogService.AskAsync("This is the alert");

      if (answer)
      {
        Console.WriteLine("Test");

        // TODO Hook up logging for Maui

        await _dialogService.Show("Document saved.");
      }
      else
      {
        await _dialogService.Show("Document NOT saved.");
      }
    }
  }
}