namespace Albums.Core
{
  public interface ICounterService
  {
    string GetLabel();

    void Increment();
  }
}