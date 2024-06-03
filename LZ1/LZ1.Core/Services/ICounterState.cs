namespace LZ1.Core.Services;

public interface ICounterState
{
    public int Count { get; }

    void Increment();
}
