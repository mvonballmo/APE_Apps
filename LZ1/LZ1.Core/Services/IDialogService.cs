namespace LZ1.Core.Services;

public interface IDialogService
{
    Task<bool> AskAsync(string message);

    Task Show(string message);
}