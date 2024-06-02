using LZ1.Core.Services;

namespace LZ1.App;

public partial class MainPage : ContentPage
{
    private int _count;
    private readonly IDialogService _dialogService;

    public MainPage(IDialogService dialogService)
    {
        _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));

        InitializeComponent();
    }

    private async void OnCounterClicked(object? sender, EventArgs e)
    {
        var increment = await _dialogService.AskAsync("Are you sure you want to increment?");

        if (increment)
        {
            _count++;

            var suffix = _count == 1 ? string.Empty : "s";

            CounterBtn.Text = $"Clicked {_count} time{suffix}";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}