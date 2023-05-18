namespace Albums;

using Albums.Core;

public partial class MainPage : ContentPage
{
	private readonly CounterService counterService;

	public MainPage(CounterService counterService)
	{
		InitializeComponent();

		this.counterService = counterService;
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		counterService.Increment();

		CounterBtn.Text = counterService.GetLabel();

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

