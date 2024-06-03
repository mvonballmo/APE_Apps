namespace LZ1.Core.Services;

public interface ICounterService
{
    string GetLabel();

    void Increment();

    Task<bool> TryIncrement();
}
