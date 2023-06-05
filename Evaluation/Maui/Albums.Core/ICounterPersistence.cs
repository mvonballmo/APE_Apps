namespace Albums.Core
{
  public interface ICounterPersistence
  {
    Task Save(ICounterState state);
  }
}