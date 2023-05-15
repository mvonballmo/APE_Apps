using Albums.Core;

namespace Albums;

public partial class MainPage : ContentPage
{
	private CounterService counterService;

    public MainPage(CounterService counterService)
	{
		InitializeComponent();

		this.counterService = counterService;
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		counterService.Increase();
		CounterBtn.Text = counterService.GetLabel();

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

