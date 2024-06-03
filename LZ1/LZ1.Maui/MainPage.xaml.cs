using LZ1.Core;
using LZ1.Core.Services;

namespace LZ1.App;

public partial class MainPage : ContentPage
{
    private readonly ICounterService _counterService;

    public MainPage(ICounterService counterService)
    {
        _counterService = counterService ?? throw new ArgumentNullException(nameof(counterService));

        InitializeComponent();
    }

    private async void OnCounterClicked(object? sender, EventArgs e)
    {
        if (await _counterService.TryIncrement())
        {
            CounterBtn.Text = _counterService.GetLabel();

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}