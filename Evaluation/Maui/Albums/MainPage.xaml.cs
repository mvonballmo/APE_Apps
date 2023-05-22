namespace Albums;

public partial class MainPage : ContentPage
{
  private readonly ICounterService counterService;
  private readonly ICounterState state;
  private readonly ICounterPersistence persistence;

  public MainPage(ICounterService counterService, ICounterState state)
  {
    InitializeComponent();

    this.counterService = counterService;
    this.state = state;
  }

  private void OnCounterClicked(object sender, EventArgs e)
  {
    counterService.Increment();

    CounterBtn.Text = counterService.GetLabel();

    SemanticScreenReader.Announce(CounterBtn.Text);
  }

  async void SaveClicked(Object sender, EventArgs e)
  {
    //ISaveChecker
    //IDialogService
    var answer = await DisplayAlert("Alert", "This is the alert", "Cancel", "OK");

    if (answer)
    {
      persistence.Save(state);
    }
  }
}

