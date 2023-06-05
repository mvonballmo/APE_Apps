namespace Albums.Core
{
  public interface ICounterPersistence
  {
    void Save(ICounterState state);
  }
}