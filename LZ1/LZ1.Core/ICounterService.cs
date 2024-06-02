namespace LZ1.Core;

public interface ICounterService
{
    string GetLabel();

    void Increment();
}
