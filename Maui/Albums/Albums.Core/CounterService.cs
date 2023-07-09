namespace Albums.Core;

internal class CounterService : ICounterService
{
  private readonly ICounterState _state;

  public CounterService(ICounterState state)
  {
    _state = state;
  }

  public void Increment()
  {
    _state.Count += 1;
  }

  public string GetLabel()
  {
    var countLabel = _state.Count == 1 ? "time" : "times";

    return $"Clicked {_state.Count} {countLabel}";
  }
}