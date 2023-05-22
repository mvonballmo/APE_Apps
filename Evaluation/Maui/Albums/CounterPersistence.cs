using CoreBluetooth;

namespace Albums
{

  internal class CounterPersistence : ICounterPersistence
  {
    public void Save(ICounterState state)
    {
      var answer = await DisplayAlert("Alert", "This is the alert", "OK", "Cancel");

      throw new NotImplementedException();
    }
  }
}