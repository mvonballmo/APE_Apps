namespace Albums.Core
{
  public class CounterPersistence : ICounterPersistence
  {
    public void Save(ICounterState state)
    {
      //var answer = await DisplayAlert("Alert", "This is the alert", "OK", "Cancel");

      // TODO Hook up logging for Maui

      Console.WriteLine("Test");
    }
  }
}