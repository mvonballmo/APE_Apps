namespace Albums
{
  internal interface ICounterPersistence
  {
    void Save(ICounterState state);
  }
}