namespace Albums;

public class SubService
{

}

public class CounterService
{
    int count = 0;
    private readonly SubService subService;

    public CounterService(SubService subService)
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

