namespace Albums;

public class CounterService : ICounterService
{
    int count = 0;
    private readonly ISubService subService;

    public CounterService(ISubService subService)
    {
        this.subService = subService;
    }

    public void Increment()
    {
        count += 1;
    }

    public string GetLabel()
    {
        string countLabel = count == 1 ? "time" : "times";

        return $"Clicked {count} {countLabel}";
    }
}

