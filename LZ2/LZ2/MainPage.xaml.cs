using Core;

namespace LZ2;

public partial class MainPage : ContentPage
{
    private readonly MainPageViewModel _viewModel;

    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = _viewModel = viewModel;
    }

    private void OnCounterClicked(object? sender, EventArgs e)
    {
        _viewModel.Increment();
    }

    private async void OnSaveClicked(object? sender, EventArgs e)
    {
        await _viewModel.Save();
        await DisplayAlert("Save complete", "Your data has been saved.", "OK");
    }

    private void OnAddClicked(object? sender, EventArgs e)
    {
        _viewModel.Add();
    }
}