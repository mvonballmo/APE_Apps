namespace Albums;

public partial class MainPage : ContentPage
{
  private readonly ICounterService counterService;
  private readonly ICounterState state;
  private readonly ICounterPersistence persistence;
  private readonly IDialogService dialogService;

  public MainPage(ICounterService counterService, ICounterState state, IDialogService dialogService, ICounterPersistence persistence)
  {
    InitializeComponent();

    this.counterService = counterService;
    this.state = state;
    this.dialogService = dialogService;
    this.persistence = persistence;
  }

  private void OnCounterClicked(object sender, EventArgs e)
  {
    counterService.Increment();

    CounterBtn.Text = counterService.GetLabel();

    SemanticScreenReader.Announce(CounterBtn.Text);
  }

  async void SaveClicked(Object sender, EventArgs e)
  {
    var answer = await dialogService.AskAsync(this, "This is the alert");

    // runs AFTER the user answers

    if (answer)
    {
      persistence.Save(state);

      await dialogService.Show(this, "Document saved.");
    }
    else
    {
      await dialogService.Show(this, "Document NOT saved.");
    }
  }
}

