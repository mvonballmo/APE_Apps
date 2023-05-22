namespace Albums;

public class CounterService : ICounterService
{
    private readonly ICounterState state;

    public CounterService(ICounterState state)
    {
        this.state = state;
    }

    public void Increment()
    {
        state.Count += 1;
    }

    public string GetLabel()
    {
        string countLabel = state.Count == 1 ? "time" : "times";

        return $"Clicked {state.Count} {countLabel}";
    }
}

