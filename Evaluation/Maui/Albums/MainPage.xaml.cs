using Albums.Core;

namespace Albums;

public partial class MainPage : ContentPage
{
	private CounterService counterService = new();

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		counterService.Increase();
		CounterBtn.Text = counterService.GetLabel();

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

