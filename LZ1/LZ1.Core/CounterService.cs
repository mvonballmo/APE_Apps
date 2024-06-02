namespace LZ1.Core;

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
        var suffix = _state.Count == 1 ? string.Empty : "s";

        return $"Clicked {_state.Count} time{suffix}";
    }
}