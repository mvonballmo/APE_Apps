using Albums.Core;

namespace Albums
{
  public interface ICounterPersistence
  {
    void Save(ICounterState state);
  }
}