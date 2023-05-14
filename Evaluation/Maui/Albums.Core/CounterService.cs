namespace Albums.Core;

// All the code in this file is included in all platforms.
public class CounterService
{
    private int count;

    public void Increase()
    {
        count++;
    }

    public string GetLabel()
    {
        return count == 1 ? $"Clicked {count} time" : $"Clicked {count} times";
    }
}
