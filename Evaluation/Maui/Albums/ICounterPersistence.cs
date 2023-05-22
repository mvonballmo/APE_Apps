namespace Albums
{
  internal interface ICounterPersistence
  {
    void Save(ICounterState state);
  }

  internal class CounterPersistence : ICounterPersistence
  {
    public void Save(ICounterState state)
    {
      throw new NotImplementedException();
    }
  }
}